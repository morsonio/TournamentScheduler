namespace Scheduler.Domain.Entities
{
    public class Match
    {
        public int Id { get; set; }

        // Klucze obce i właściwości nawigacyjne dla drużyn
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        // Klucz obcy i właściwość nawigacyjna dla stadionu
        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }

        // Klucz obcy i właściwość nawigacyjna dla kolejki
        public int RoundId { get; set; }
        public Round Round { get; set; }

        // Klucz obcy i właściwość nawigacyjna dla terminarza
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}