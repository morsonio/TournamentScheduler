namespace Scheduler.Application.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string CompetitionName { get; set; }
        public DateTime GeneratedDate { get; set; }
        public List<MatchDto> Matches { get; set; } = new List<MatchDto>();
    }
}