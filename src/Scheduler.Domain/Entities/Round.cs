namespace Scheduler.Domain.Entities
{
    public class Round
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; } // np. 1, 2, 3...

        // Klucz obcy dla Rozgrywek
        public int CompetitionId { get; set; }
        // Właściwość nawigacyjna: Kolejka należy do jednych rozgrywek
        public Competition Competition { get; set; }

        // Właściwość nawigacyjna: W jednej kolejce jest wiele meczy
        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}