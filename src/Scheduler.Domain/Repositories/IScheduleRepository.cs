using Scheduler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Domain.Repositories
{
    internal interface IScheduleRepository
    {
        Task<Schedule> GetByCompetitionIdWithMatchesAsync(int competitionId);
    }
}
