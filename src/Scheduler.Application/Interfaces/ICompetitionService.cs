using Scheduler.Application.DTOs;

namespace Scheduler.Application.Interfaces
{
    public interface ICompetitionService
    {
        Task<IEnumerable<CompetitionDto>> GetAllCompetitionsAsync();
        Task<ScheduleDto> GetScheduleForCompetitionAsync(int competitionId);
    }
}