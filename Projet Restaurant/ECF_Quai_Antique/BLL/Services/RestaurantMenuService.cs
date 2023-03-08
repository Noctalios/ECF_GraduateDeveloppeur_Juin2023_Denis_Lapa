using ECF_Quai_Antique.BLL.Interfaces;
using ECF_Quai_Antique.DAL.Interfaces;
using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.BLL.Interfaces
{
    public class RestaurantMenuService : IRestaurantMenuService
    {
        private IRestaurantMenuData RestaurantMenuData;

        public RestaurantMenuService(IRestaurantMenuData restaurantMenuData)
        {
            RestaurantMenuData = restaurantMenuData;
        }

        public List<Dish> GetDishes()
        {
            return RestaurantMenuData.GetDishes();
        }

        public List<DishType> GetDishTypes()
        {
            return RestaurantMenuData.GetDishTypes();
        }

        public List<Menu> GetMenus()
        {
            return RestaurantMenuData.GetMenus();
        }

        public void SaveDishes(List<Dish> dishes)
        {
            RestaurantMenuData.SaveDishes(dishes);
        }

        public void SaveMenus(List<Menu> menus)
        {
            RestaurantMenuData.SaveMenus(menus);
        }

        public void SaveFormulas(List<Formula> formulas)
        {
            RestaurantMenuData.SaveFormulas(formulas);
        }

    }
}
