namespace ECF_Quai_Antique.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Formula> Formulas { get; set; }

        public Menu() { }

        public Menu(int id, string name, List<Formula> formulas)
        {
            Id = id;
            Name = name;
            Formulas = formulas;
        }
    }
}
