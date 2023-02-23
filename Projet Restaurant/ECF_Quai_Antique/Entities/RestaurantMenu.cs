namespace ECF_Quai_Antique.Entities
{
    public class RestaurantMenu
    {
        private int Id { get; set; }

        private string Name { get; set; }

        List<Menu> Menus { get; set; }

        List<Dish> Dishes { get; set; }

        public RestaurantMenu(int id, string name, List<Menu> menus, List<Dish> dishes)
        {
            Id = id;
            Name = name;
            Menus = menus;
            Dishes = dishes;
        }
    }
}
