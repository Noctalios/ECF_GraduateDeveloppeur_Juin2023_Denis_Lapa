namespace ECF_Quai_Antique.Entities
{
    public class Allergie
    {
        private int Id { get; set; }

        private string Name { get; set; }

        public Allergie(string name)
        {
            Name = name;
        }
    }
}
