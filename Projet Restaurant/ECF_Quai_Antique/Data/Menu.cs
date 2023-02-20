namespace ECF_Quai_Antique.Data
{
    public class Menu
    {
        private int Id { get; set; }

        private string Name { get; set; }

        private string Description { get; set; }

        private List<Formula> Formulas { get; set; }

        public Menu(string name, string description, List<Formula> formulas) 
        {
            this.Name = name;
            this.Description = description;
            this.Formulas = formulas;
        }
    }
}
