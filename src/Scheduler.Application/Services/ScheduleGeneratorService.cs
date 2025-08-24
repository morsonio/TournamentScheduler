using Scheduler.Application.DTOs;
using Scheduler.Application.Interfaces;
using Scheduler.Domain.Repositories;
using Scheduler.Domain.Services;

namespace Scheduler.Application.Services
{
    internal class ScheduleGeneratorService : IScheduleGeneratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IScheduleGenerator _scheduleGenerator;

        public ScheduleGeneratorService(IUnitOfWork unitOfWork, IScheduleGenerator scheduleGenerator)
        {
            _unitOfWork = unitOfWork;
            _scheduleGenerator = scheduleGenerator;
        }
        public async Task<ScheduleDto> GenerateAndSaveScheduleAsync(int competitionId)
        {
            // 1. Pobranie danych wejściowych dla algorytmu
            var competition = await _unitOfWork.Competitions.GetByIdWithTeamsAsync(competitionId);
            if (competition == null)
            {
                throw new Exception($"Competition with ID {competitionId} not found.");
            }

            // 2. Wywołanie logiki domenowej (algorytmu) w celu wygenerowania terminarza
            // Serwis aplikacyjny nie wie, JAK terminarz jest generowany, tylko zleca to zadanie.
            var newSchedule = _scheduleGenerator.Generate(competition);

            // 3. Zapisanie wyniku w bazie danych w ramach jednej transakcji
            await _unitOfWork.Schedules.AddAsync(newSchedule);
            await _unitOfWork.CompleteAsync();

            // 4. Zmapowanie wyniku na DTO i zwrócenie go do UI
            return new ScheduleDto
            {
                Id = newSchedule.Id,
                CompetitionName = newSchedule.Competition.Name,
                GeneratedDate = newSchedule.GeneratedDate,
                Matches = newSchedule.Matches.Select(m => new MatchDto
                {
                    RoundNumber = m.Round.RoundNumber,
                    HomeTeamName = m.HomeTeam.Name,
                    AwayTeamName = m.AwayTeam.Name,
                    StadiumName = m.Stadium.Name
                }).ToList()
            };
        }
    }
}
