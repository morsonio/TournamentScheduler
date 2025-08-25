using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Services
{
    public class BacktrackingScheduleGenerator : IScheduleGenerator
    {

        private record Matchup(Team Home, Team Away);
        private record ProposedMatch(Matchup Matchup, Round Round);

        public Schedule Generate(Competition competition)
        {
            var teams = competition.Baskets.SelectMany(b => b.Teams).ToList();
            var rounds = competition.Rounds.OrderBy(r => r.RoundNumber).ToList();

            var newSchedule = new Schedule
            {
                CompetitionId = competition.Id,
                Competition = competition,
                GeneratedDate = DateTime.UtcNow
            };

            var builder = new ScheduleBuilder(teams, rounds);
            bool success = builder.TryBuild(out var solution);

            if (!success)
            {
                throw new InvalidOperationException("Could not generate a valid schedule with the given constraints.");
            }

            newSchedule.Matches = builder.GetResultingMatches(newSchedule, solution);
            return newSchedule;
        }

        private class ScheduleBuilder
        {
            private readonly List<Round> _rounds;
            private readonly List<Matchup> _potentialMatchups;
            private readonly ConstraintValidator _validator;

            public ScheduleBuilder(List<Team> teams, List<Round> rounds)
            {
                _rounds = rounds;
                _validator = new ConstraintValidator();

                _potentialMatchups = new List<Matchup>();
                for (int i = 0; i < teams.Count; i++)
                {
                    for (int j = i + 1; j < teams.Count; j++)
                    {
                        _potentialMatchups.Add(new Matchup(teams[i], teams[j]));
                        _potentialMatchups.Add(new Matchup(teams[j], teams[i]));
                    }
                }
                _potentialMatchups = _potentialMatchups.OrderBy(x => Guid.NewGuid()).ToList();
            }

            public bool TryBuild(out List<ProposedMatch> solution)
            {
                solution = new List<ProposedMatch>();
                return Solve(solution);
            }

            private bool Solve(List<ProposedMatch> solution)
            {
                if (solution.Count == _potentialMatchups.Count)
                {
                    return true;
                }

                var matchupToSchedule = _potentialMatchups[solution.Count];

                foreach (var round in _rounds)
                {
                    var candidate = new ProposedMatch(matchupToSchedule, round);

                    if (_validator.IsValidPlacement(solution, candidate))
                    {
                        solution.Add(candidate);
                        if (Solve(solution))
                        {
                            return true;
                        }
                        solution.RemoveAt(solution.Count - 1); // Backtrack
                    }
                }
                return false;
            }

            public ICollection<Match> GetResultingMatches(Schedule schedule, List<ProposedMatch> solution)
            {
                return solution.Select(p => new Match
                {
                    Schedule = schedule,
                    HomeTeam = p.Matchup.Home,
                    AwayTeam = p.Matchup.Away,
                    Round = p.Round,
                    Stadium = p.Matchup.Home.Stadium
                }).ToList();
            }
        }

        private class ConstraintValidator
        {
            public bool IsValidPlacement(List<ProposedMatch> currentSolution, ProposedMatch candidate)
            {
                var homeTeam = candidate.Matchup.Home;
                var awayTeam = candidate.Matchup.Away;
                var round = candidate.Round;

                // Reguła 1: Drużyna nie może rozegrać dwóch meczy w tej samej kolejce
                if (currentSolution.Any(m => m.Round == round && (m.Matchup.Home == homeTeam || m.Matchup.Away == homeTeam)))
                    return false;

                if (currentSolution.Any(m => m.Round == round && (m.Matchup.Home == awayTeam || m.Matchup.Away == awayTeam)))
                    return false;

                // Reguła 2: Drużyny nie mogą być z tego samego kraju
                if (homeTeam.CountryId == awayTeam.CountryId)
                    return false;

                // Inne reguły można dodać tutaj w ten sam, bezstanowy sposób.

                return true;
            }
        }
    }
}