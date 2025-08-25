using Microsoft.EntityFrameworkCore;
using Scheduler.Domain.Entities;
using Scheduler.Domain.Repositories;
using Scheduler.Infrastructure.Persistence;

namespace Scheduler.Infrastructure.Repositories
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(SchedulerDbContext context) 
            : base(context)
        {
        }

        public async Task<Schedule> GetByCompetitionIdWithMatchesAsync(int competitionId)
        {
            return await _context.Schedules
               .Include(s => s.Competition)
               .Include(s => s.Matches)
                   .ThenInclude(m => m.HomeTeam)
               .Include(s => s.Matches)
                   .ThenInclude(m => m.AwayTeam)
               .Include(s => s.Matches)
                   .ThenInclude(m => m.Round)
               .Include(s => s.Matches)
                   .ThenInclude(m => m.Stadium)
               .FirstOrDefaultAsync(s => s.CompetitionId == competitionId);
        }
    }
}