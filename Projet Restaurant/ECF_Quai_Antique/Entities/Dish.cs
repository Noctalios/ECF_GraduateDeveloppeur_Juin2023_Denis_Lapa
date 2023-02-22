namespace ECF_Quai_Antique.Entities
{
    public class Dish
    {
        private int Id { get; set; }
        
        private string Name { get; set; }

        private string Description { get; set; }

        private DishType DishType { get; set; }

        private decimal Price { get; set; }

        public Dish(string name, string description, DishType dishType, decimal price) 
        {
            this.Name = name;
            this.Description = description;
            this.DishType = dishType;
            this.Price = price;
        }
    }
}
