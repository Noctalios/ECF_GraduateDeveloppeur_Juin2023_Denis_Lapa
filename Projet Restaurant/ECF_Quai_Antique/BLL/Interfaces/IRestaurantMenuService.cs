using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.BLL.Interfaces
{
    public interface IRestaurantMenuService
    {
        List<Dish> GetDishes();
        List<Menu> GetMenus();
        List<DishType> GetDishTypes();
        void SaveDishes(List<Dish> dishes);
        void SaveMenus(List<Menu> menus);
        void SaveFormulas(List<Formula> formulas);
    }
}
