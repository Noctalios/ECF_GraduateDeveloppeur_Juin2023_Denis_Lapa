using ECF_Quai_Antique.Entities;
using ECF_Quai_Antique.Interfaces;
using Microsoft.Data.SqlClient;

namespace ECF_Quai_Antique.DAL
{
    public class RestaurantData : IRestaurantData
    {
        #region CREATE

        public void CreateBookings(DateTime datetime, string name, int guest, List<Allergie> allergies)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[CreateBooking] @Date, @Name, @Guest, @Allergens ;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Date", datetime);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Guest", guest);
                    // @ allergens = allergies

                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }
            catch (SqlException e)
            { 
                Console.Write(e.Message);
            }
        }

        #endregion

        #region READ

        public Restaurant GetRestaurant()
        {
            try
            {
                Restaurant restaurant = new Restaurant();
                restaurant.WorkDays = new List<WorkDay> { new WorkDay() };

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[GetRestaurant]";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            restaurant.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            restaurant.Name = reader.GetString(reader.GetOrdinal("Name"));
                            restaurant.Guest = reader.GetInt32(reader.GetOrdinal("Guest"));
                            //restaurant.Workdays à garnir mais c'est une liste
                        }

                        return restaurant;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Booking> GetBookings()
        {
            try
            {
                List<Booking> bookings = new List<Booking>();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[GetBookings];";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                ClientName = reader.GetString(reader.GetOrdinal("Name")),
                                Guest = reader.GetInt32(reader.GetOrdinal("guest"))
                                // Ajout des list d'allergens
                            };
                            bookings.Add(booking);
                        }
                    }
                }

                return bookings;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        #endregion

        #region UPDATE

        public void UpdateRestaurant(Restaurant restaurant)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

                string sql = "EXEC [dbo].[UpdateRestaurant] @RetstaurantId, @Guest, @Periods ;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@RestaurantId", restaurant.Id);
                    command.Parameters.AddWithValue("@Guest", restaurant.Guest);
                    //Fill parameter @Periods with periods id open and close

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}
