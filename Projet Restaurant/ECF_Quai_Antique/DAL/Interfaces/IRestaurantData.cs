using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.DAL.Interfaces
{
    public interface IRestaurantData
    {
        void CreateBookings(DateTime datetime, string name, int guest, List<Allergie> allergies);
        Restaurant GetRestaurant();
        List<Booking> GetBookings();
        void UpdateRestaurant(Restaurant restaurant);
    }
}
