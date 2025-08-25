using Scheduler.Domain.Repositories;
using Scheduler.Infrastructure.Persistence;

namespace Scheduler.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SchedulerDbContext _context;

        public ICompetitionRepository Competitions { get; private set; }
        public IScheduleRepository Schedules { get; private set; }

        public UnitOfWork(SchedulerDbContext context)
        {
            _context = context;
            Competitions = new CompetitionRepository(_context);
            Schedules = new ScheduleRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}