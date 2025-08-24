using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Repositories
{
    public interface IScheduleRepository
    {
        Task<Schedule> GetByCompetitionIdWithMatchesAsync(int competitionId);
    }
}
