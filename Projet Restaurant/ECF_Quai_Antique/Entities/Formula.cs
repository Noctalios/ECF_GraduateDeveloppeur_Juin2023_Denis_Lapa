namespace ECF_Quai_Antique.Entities
{
    public class Formula
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public List<DishType> DishTypes { get; set; }

        public Formula() { }

        public Formula(int id, string description, decimal price, List<DishType>  dishTypes) 
        {
            Id = id;
            Description = description;
            Price = price;
            DishTypes = dishTypes;
        }
    }
}
