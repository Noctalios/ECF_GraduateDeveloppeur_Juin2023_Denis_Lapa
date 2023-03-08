using ECF_Quai_Antique.DAL.Interfaces;
using ECF_Quai_Antique.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ECF_Quai_Antique.DAL.Repository
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
                    
                    // Parameter @Allergens
                    SqlParameter parameter = command.Parameters.AddWithValue("@Allergens", CreateAllergiesDataTable(allergies));
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.AllergiesTableType";

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
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[GetRestaurant]";

                Dictionary<int, Restaurant> result = new Dictionary<int, Restaurant>();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (result.TryGetValue(reader.GetInt32("Id"), out Restaurant restaurant))
                            {
                                WorkDay currentWorkDay = restaurant.WorkDays.FirstOrDefault(x => x.Day.Id == reader.GetInt32("DayId"));
                                if (currentWorkDay != null)
                                {
                                    currentWorkDay.Periods.Add(new Period()
                                    {
                                        Id = reader.GetInt32("PeriodId"),
                                        Service = reader.GetInt32("PeriodId") % 2,
                                        Open = reader.GetDateTime("Open"),
                                        Close = reader.GetDateTime("Close")
                                    });
                                }
                                else
                                {
                                    restaurant.WorkDays.Add(new WorkDay()
                                    {
                                        Day = new Day(reader.GetInt32("DayId"), reader.GetString("DayLabel")),
                                        Periods = new List<Period>()
                                        {
                                            new Period()
                                            {
                                                Id = reader.GetInt32("PeriodId"),
                                                Service = reader.GetInt32("PeriodId") % 2,
                                                Open = reader.GetDateTime("Open"),
                                                Close = reader.GetDateTime("Close")
                                            }
                                        }
                                    });
                                }
                            }
                            else
                            {
                                Restaurant newRestaurant = new Restaurant()
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Label"),
                                    Guest = reader.GetInt32("Guest"),
                                    WorkDays = new List<WorkDay>()
                                    {
                                        new WorkDay()
                                        {
                                            Day = new Day(reader.GetInt32("DayId"), reader.GetString("DayLabel")),
                                            Periods = new List<Period>()
                                            {
                                                new Period()
                                                {
                                                    Id = reader.GetInt32("PeriodId"),
                                                    Service = reader.GetInt32("PeriodId") % 2,
                                                    Open = reader.GetDateTime("Open"),
                                                    Close = reader.GetDateTime("Close")
                                                }
                                            }
                                        }
                                    }
                                };
                                result.Add(reader.GetInt32("Id"), newRestaurant);
                            }
                        }
                        return result.Values.FirstOrDefault();
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
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[GetBookings];";

                Dictionary<int, Booking> result = new Dictionary<int, Booking>();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (result.TryGetValue(reader.GetInt32("Id"), out Booking booking))
                            {
                                booking.Allergens.Add(new Allergie()
                                {
                                    Id= reader.GetInt32("AllergieId"),
                                    Name = reader.GetString("AllergieName")
                                });
                            }
                            else
                            {
                                Booking newBooking = new Booking()
                                {
                                    Id = reader.GetInt32("Id"),
                                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                    ClientName = reader.GetString(reader.GetOrdinal("Name")),
                                    Guest = reader.GetInt32(reader.GetOrdinal("guest")),
                                    Allergens = new List<Allergie>()
                                    {
                                        new Allergie()
                                        {
                                            Id = reader.GetInt32("AllergieId"),
                                            Name = reader.GetString("AllergieName")
                                        }
                                    }
                                };
                                result.Add(reader.GetInt32("Id"), newBooking);
                            }
                        }
                    }
                }
                return result.Values.ToList();
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
                    // Parameter @Periods
                    SqlParameter parameter = command.Parameters.AddWithValue("@Periods", CreatePeriodsDataTable(restaurant));
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.PeriodsTableType";

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

        #region DataTable

        private DataTable CreateAllergiesDataTable(List<Allergie> allergies)
        {
            DataTable allergiesDataTable = new DataTable();
            allergiesDataTable.Columns.Add("Label", typeof(string));

            if (allergies != null)
            {
                foreach (var allergie in allergies)
                {
                    allergiesDataTable.LoadDataRow(new object[]
                    {
                        allergie.Name
                    },
                    true);
                }
            }

            return allergiesDataTable;
        }

        private DataTable CreatePeriodsDataTable(Restaurant restaurant)
        {
            DataTable periodsDataTable = new DataTable();
            periodsDataTable.Columns.Add("Id", typeof(int));
            periodsDataTable.Columns.Add("Open", typeof(TimeOnly));
            periodsDataTable.Columns.Add("Close", typeof(TimeOnly));

            if (restaurant != null)
            {
                foreach (var workDay in restaurant.WorkDays)
                {
                    foreach (var period in workDay.Periods)
                    {
                        periodsDataTable.LoadDataRow(new object[]
                        {
                            period.Id,
                            period.Open,
                            period.Close
                        },
                        true);
                    }
                }
            }
            
            return periodsDataTable;
        }

        #endregion
    }
}
