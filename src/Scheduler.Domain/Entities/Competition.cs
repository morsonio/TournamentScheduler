namespace Scheduler.Domain.Entities
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Właściwość nawigacyjna: Rozgrywki mają wiele koszyków
        public ICollection<Basket> Baskets { get; set; } = new List<Basket>();

        // Właściwość nawigacyjna: Rozgrywki mają wiele kolejek
        public ICollection<Round> Rounds { get; set; } = new List<Round>();

        // Właściwość nawigacyjna: Rozgrywki mają jeden wygenerowany terminarz
        public Schedule Schedule { get; set; }
    }
}