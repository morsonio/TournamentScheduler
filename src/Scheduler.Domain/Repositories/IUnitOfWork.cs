namespace Scheduler.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ICompetitionRepository Competitions { get; }
        IScheduleRepository Schedules { get; }

        Task<int> CompleteAsync();
    }
}