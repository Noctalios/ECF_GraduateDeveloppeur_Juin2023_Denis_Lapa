namespace ECF_Quai_Antique.Entities
{
    public class Menu
    {
        private int Id { get; set; }

        private string Name { get; set; }

        private string Description { get; set; }

        private List<Dish> Dishes { get; set; }
        
        private List<Formula> Formulas { get; set; }

        public Menu(string name, string description, List<Dish> dishes,List<Formula> formulas) 
        {
            this.Name = name;
            this.Description = description;
            this.Formulas = formulas;
            this.Dishes = dishes;
        }
    }
}
