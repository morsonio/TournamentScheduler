namespace Scheduler.Domain.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string Name { get; set; } // np. "Koszyk 1"

        // Klucz obcy dla Rozgrywek
        public int CompetitionId { get; set; }
        // Właściwość nawigacyjna: Koszyk należy do jednych rozgrywek
        public Competition Competition { get; set; }

        // Właściwość nawigacyjna: W jednym koszyku jest wiele drużyn
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}