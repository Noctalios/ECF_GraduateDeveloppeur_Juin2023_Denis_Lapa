namespace ECF_Quai_Antique.Data
{
    public class Formula
    {
        private int Id { get; set; }

        private string Description { get; set; }

        private decimal Price { get; set; }

        private List<DishType> DishTypes { get; set; }

        public Formula(string description, decimal price, List<DishType> DishTypes) 
        {
            this.Description = description;
            this.Price = price;
            this.DishTypes = DishTypes;
        }
    }
}
