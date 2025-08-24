using Scheduler.Application.DTOs;
using Scheduler.Application.Interfaces;
using Scheduler.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Application.Services
{
    internal class ScheduleGeneratorService : IScheduleGeneratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IScheduleGenerator _scheduleGenerator;

        public ScheduleGeneratorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_scheduleGenerator = scheduleGenerator;
        }
        public Task<ScheduleDto> GenerateAndSaveScheduleAsync(int competitionId)
        {
            throw new NotImplementedException();
        }
    }
}
