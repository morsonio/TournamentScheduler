using Microsoft.EntityFrameworkCore;
using Scheduler.Domain.Entities;
using Scheduler.Domain.Repositories;
using Scheduler.Infrastructure.Persistence;

namespace Scheduler.Infrastructure.Repositories
{
    public class CompetitionRepository : GenericRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(SchedulerDbContext context) 
            : base(context)
        {
        }

        public async Task<Competition> GetByIdWithTeamsAsync(int competitionId)
        {
            // Eager Loading
            return await _context.Competitions
               .Include(c => c.Baskets)
                   .ThenInclude(b => b.Teams)
                       .ThenInclude(t => t.Country)
               .Include(c => c.Baskets)
                   .ThenInclude(b => b.Teams)
                       .ThenInclude(t => t.Stadium)
               .Include(c => c.Rounds)
               .FirstOrDefaultAsync(c => c.Id == competitionId);
        }
    }
}