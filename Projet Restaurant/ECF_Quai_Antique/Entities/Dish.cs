namespace ECF_Quai_Antique.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public DishType DishType { get; set; }

        public decimal Price { get; set; }

        public Dish(int id, string name, string description, DishType dishType, decimal price) 
        {
            Id = id;
            Name = name;
            Description = description;
            DishType = dishType;
            Price = price;
        }
    }
}
