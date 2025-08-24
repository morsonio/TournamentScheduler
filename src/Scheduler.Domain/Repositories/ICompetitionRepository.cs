using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Repositories
{
    public interface ICompetitionRepository:IGenericRepository<Competition>
    {
        Task<IEnumerable<Competition>> GetAllAsync();
        Task<Competition> GetByIdWithTeamsAsync(int competitionId);
    }
}
