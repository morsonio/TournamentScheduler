using Scheduler.Application.DTOs;
using Scheduler.Application.Interfaces;
using Scheduler.Domain.Repositories;

namespace Scheduler.Application.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompetitionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CompetitionDto>> GetAllCompetitionsAsync()
        {
            var competitions = await _unitOfWork.Competitions.GetAllAsync();
            return competitions.Select(c=> new CompetitionDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<ScheduleDto> GetScheduleForCompetitionAsync(int competitionId)
        {
            var schedule = await _unitOfWork.Schedules.GetByCompetitionIdWithMatchesAsync(competitionId);

            if (schedule == null)
            {
                throw new KeyNotFoundException($"Competition with ID {competitionId} not found.");
            }

            return new ScheduleDto
            {
                Id = schedule.Id,
                CompetitionName = schedule.Competition.Name,
                GeneratedDate = schedule.GeneratedDate,
                Matches = schedule.Matches.Select(m => new MatchDto
                {
                    AwayTeamName = m.AwayTeam.Name,
                    HomeTeamName = m.HomeTeam.Name,
                    StadiumName = m.Stadium.Name,
                    RoundNumber = m.Round.RoundNumber
                }).ToList()
            };
        }
    }
}
