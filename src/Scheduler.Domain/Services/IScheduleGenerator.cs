using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Services
{
    public interface IScheduleGenerator
    {
        Schedule Generate(Competition competition);
    }
}
