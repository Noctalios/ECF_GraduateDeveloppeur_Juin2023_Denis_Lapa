namespace ECF_Quai_Antique.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Formula> Formulas { get; set; }

        public Menu(int id, string name, string description, List<Dish> dishes,List<Formula> formulas) 
        {
            Id = id;
            Name = name;
            Description = description;
            Formulas = formulas;
        }
    }
}
