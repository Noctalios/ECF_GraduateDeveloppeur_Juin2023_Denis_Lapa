using ECF_Quai_Antique.Entities;
using Microsoft.Data.SqlClient;

namespace ECF_Quai_Antique.DAL
{
    public class RestaurantMenuData
    {
        #region READ

        public List<Dish> GetDishes()
        {
            try
            {
                List<Dish> dishes = new List<Dish>();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[GetDishes]";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dish dish = new Dish()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Label")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                DishType = new DishType
                                (
                                    reader.GetInt32(reader.GetOrdinal("DishTypeId")),
                                    reader.GetString(reader.GetOrdinal("DishTypeLabel"))
                                )
                            };
                            dishes.Add(dish);
                        }
                    }
                }
                return dishes;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Menu> GetMenus()
        {
            try
            {
                List<Menu> menus = new List<Menu>();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[GetMenus]";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Menu menu = new Menu()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("MenuId")),
                                Name = reader.GetString(reader.GetOrdinal("MenuLabel")),
                                // Add Formulas with FormulaId, FormulaDescription, FormulaPrice,
                                    // DishTypes with DishId and DishTypeLabel
                            };
                            menus.Add(menu);
                        }
                    }
                }
                return menus;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        #endregion

        #region SAVE
        
        public void SaveDishes(List<Dish> dishes)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[SaveDishes] @Dishes;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) 
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    //Fill @Dishes with the list of Dish

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
        }

        public void SaveMenus(List<Menu> menus)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[SaveMenus] @Menus, @MenuFormulas;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    //Fill @Menus with Menu.Id, Menu.Name
                    //Fill @MenuFormulas whit Formula.Id and MenuId

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
        }

        public void SaveFormulas(List<Formula>formulas)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[SaveDishes] @Formulas, @FormulasDishType;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    //Fill @Formulas with Formula.Id, formula.Description, formula.Price
                    //Fill @FormulasDishTypes whit Formula.Id and DishType Id

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
        }

        #endregion
    }
}
