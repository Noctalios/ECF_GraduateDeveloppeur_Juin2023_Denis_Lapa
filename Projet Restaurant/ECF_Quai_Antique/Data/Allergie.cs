namespace ECF_Quai_Antique.Data
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
