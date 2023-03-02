namespace ECF_Quai_Antique.Entities
{
    public class Allergie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Allergie(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
