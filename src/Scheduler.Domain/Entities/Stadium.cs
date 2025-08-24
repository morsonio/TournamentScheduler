namespace Scheduler.Domain.Entities
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Właściwość nawigacyjna: Jeden stadion jest stadionem domowym dla jednej drużyny (relacja 1-do-1)
        public Team Team { get; set; }

        // Właściwość nawigacyjna: Na jednym stadionie może odbyć się wiele meczy
        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}