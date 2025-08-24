using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Repositories
{
    public interface IScheduleRepository:IGenericRepository<Schedule>
    {
        Task<Schedule> GetByCompetitionIdWithMatchesAsync(int competitionId);
    }
}
