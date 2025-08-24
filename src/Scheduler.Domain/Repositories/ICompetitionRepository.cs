using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Repositories
{
    public interface ICompetitionRepository
    {
        Task<IEnumerable<Competition>> GetAllAsync();
        Task<Competition> GetByIdWithTeamsAsync(int competitionId);
    }
}
