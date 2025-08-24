namespace Scheduler.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Właściwość nawigacyjna: Jeden kraj może mieć wiele drużyn
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}