namespace castles.Models
{
    public class Castle
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string King { get; set; }

        public int? Villagers { get; set; }

        public int? Armysize { get; set; }
    }
}