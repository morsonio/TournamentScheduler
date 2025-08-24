namespace Scheduler.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Klucz obcy dla Kraju
        public int CountryId { get; set; }
        // Właściwość nawigacyjna: Drużyna należy do jednego kraju
        public Country Country { get; set; }

        // Klucz obcy dla Stadionu (relacja 1-do-1 z Stadium)
        public int StadiumId { get; set; }
        // Właściwość nawigacyjna: Drużyna ma jeden stadion domowy
        public Stadium Stadium { get; set; }

        // Klucz obcy dla Koszyka
        public int BasketId { get; set; }
        // Właściwość nawigacyjna: Drużyna należy do jednego koszyka
        public Basket Basket { get; set; }

        // Właściwości nawigacyjne dla Meczów
        public ICollection<Match> HomeMatches { get; set; } = new List<Match>();
        public ICollection<Match> AwayMatches { get; set; } = new List<Match>();
    }
}