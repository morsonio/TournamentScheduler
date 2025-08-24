using Scheduler.Application.DTOs;
using System.Threading.Tasks;

namespace Scheduler.Application.Interfaces
{
    public interface IScheduleGeneratorService
    {
        Task<ScheduleDto> GenerateAndSaveScheduleAsync(int competitionId);
    }
}