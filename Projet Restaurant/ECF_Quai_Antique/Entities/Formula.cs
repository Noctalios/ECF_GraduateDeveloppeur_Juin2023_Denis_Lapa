namespace ECF_Quai_Antique.Entities
{
    public class Formula
    {
        private int Id { get; set; }

        private string Description { get; set; }

        private decimal Price { get; set; }

        private List<DishType> DishTypes { get; set; }

        public Formula(int id, string description, decimal price, List<DishType> dishTypes) 
        {
            Id = id;
            Description = description;
            Price = price;
            DishTypes = dishTypes;
        }
    }
}
