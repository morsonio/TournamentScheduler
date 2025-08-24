namespace Scheduler.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime GeneratedDate { get; set; }

        // Klucz obcy dla Rozgrywek (relacja 1-do-1 z Competition)
        public int CompetitionId { get; set; }
        // Właściwość nawigacyjna: Terminarz jest przypisany do jednych rozgrywek
        public Competition Competition { get; set; }

        // Właściwość nawigacyjna: Terminarz zawiera wiele meczy
        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}