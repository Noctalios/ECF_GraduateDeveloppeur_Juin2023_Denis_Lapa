namespace ECF_Quai_Antique.Entities
{
    public class Day
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Day() { }

        public Day(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
