using ECF_Quai_Antique.DAL.Interfaces;
using ECF_Quai_Antique.BLL.Interfaces;
using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.BLL.Services
{
    public class RestaurantService : IRestaurantService
    {
        private IRestaurantData RestaurantData;

        public RestaurantService(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public void CreateBookings(DateTime datetime, string name, int guest, List<Allergie> allergies)
        {
            RestaurantData.CreateBookings(datetime, name, guest, allergies);
        }
        
        public Restaurant GetRestaurant()
        {
            return RestaurantData.GetRestaurant();
        }
        
        public List<Booking> GetBookings()
        {
            return RestaurantData.GetBookings();
        }
        
        public void UpdateRestaurant(Restaurant restaurant)
        {
            RestaurantData.UpdateRestaurant(restaurant);
        }
    }
}
