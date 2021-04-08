namespace castles.Models
{
    public class Knight
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Height { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }

        public int CastleId { get; set; }

        public Castle Castle { get; set; }
    }
}