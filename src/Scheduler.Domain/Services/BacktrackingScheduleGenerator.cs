using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Services
{
    public class BacktrackingScheduleGenerator : IScheduleGenerator
    {
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

            //var builder = new ScheduleBuilder(teams, rounds);
            //bool success = builder.TryBuild();

            //if (!success)
            //{
            //    // Jeśli algorytm nie znalazł rozwiązania, rzucamy wyjątek.
            //    // W przyszłości można tu zaimplementować bardziej zaawansowaną obsługę błędów.
            //    throw new InvalidOperationException("Could not generate a valid schedule with the given constraints.");
            //}

            //newSchedule.Matches = builder.GetResultingMatches(newSchedule);

            return newSchedule;
        }
    }
}
