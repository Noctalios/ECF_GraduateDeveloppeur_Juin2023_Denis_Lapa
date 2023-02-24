namespace ECF_Quai_Antique.Entities
{
    public class Menu
    {
        private int Id { get; set; }

        private string Name { get; set; }

        private string Description { get; set; }

        private List<Formula> Formulas { get; set; }

        public Menu(int id, string name, string description, List<Dish> dishes,List<Formula> formulas) 
        {
            Id = id;
            Name = name;
            Description = description;
            Formulas = formulas;
        }
    }
}
