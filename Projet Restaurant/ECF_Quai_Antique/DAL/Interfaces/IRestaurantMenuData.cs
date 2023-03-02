using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.DAL.Interfaces
{
    public interface IRestaurantMenuData
    {
        List<Dish> GetDishes();
        List<Menu> GetMenus();
        void SaveDishes(List<Dish> dishes);
        void SaveMenus(List<Menu> menus);
        void SaveFormulas(List<Formula> formulas);
    }
}
