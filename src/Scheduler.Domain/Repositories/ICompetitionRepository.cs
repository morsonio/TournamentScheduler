using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Repositories
{
    internal interface ICompetitionRepository
    {
        Task<IEnumerable<Competition>> GetAllAsync();
        Task<Competition> GetByIdWithTeamsAsync(int competitionId);
    }
}
