using ECF_Quai_Antique.Entities;
using Microsoft.Data.SqlClient;
using ECF_Quai_Antique.DAL.Interfaces;
using System.Data;

namespace ECF_Quai_Antique.DAL.Repository
{
    public class RestaurantMenuData : IRestaurantMenuData
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

                    // Parameter @Dishes
                    SqlParameter parameter = command.Parameters.AddWithValue("@Dishes", CreateDishesDataTable(dishes));
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.DishTableType";

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

                    // Parameter @Menus
                    SqlParameter Menuparameter = command.Parameters.AddWithValue("@Menus", CreateMenusDataTable(menus));
                    Menuparameter.SqlDbType = SqlDbType.Structured;
                    Menuparameter.TypeName = "dbo.MenuTableType";

                    // Parameter @MenuFormulas
                    SqlParameter menuFormulasParameter = command.Parameters.AddWithValue("@MenuFormulas", CreateMenuFormulasDataTable(menus));
                    menuFormulasParameter.SqlDbType = SqlDbType.Structured;
                    menuFormulasParameter.TypeName = "dbo.MenuFormulaTable";

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

        public void SaveFormulas(List<Formula> formulas)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[SaveFormulas] @Formulas, @FormulasDishType;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    // Parameter @Formulas
                    SqlParameter formulasParameter = command.Parameters.AddWithValue("@Formulas", CreateFormulasDataTable(formulas));
                    formulasParameter.SqlDbType= SqlDbType.Structured;
                    formulasParameter.TypeName = "dbo.FormulaTableType";

                    // Parameter @FormulasDishTypes whit Formula.Id and DishType Id
                    SqlParameter formulaDishTypeParameter = command.Parameters.AddWithValue("@FormulasDishType", CreateFormulaDishTypeDataTable(formulas));
                    formulaDishTypeParameter.SqlDbType = SqlDbType.Structured;
                    formulaDishTypeParameter.TypeName = "dbo.FormulaDishTypeTable";

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

        #region DataTable

        private DataTable CreateDishesDataTable(List<Dish> dishes)
        {
            DataTable dishesDataTable = new DataTable();
            dishesDataTable.Columns.Add("Id", typeof(int));
            dishesDataTable.Columns.Add("Label", typeof(string));
            dishesDataTable.Columns.Add("DishTypeId", typeof(int));
            dishesDataTable.Columns.Add("Description",typeof(string));
            dishesDataTable.Columns.Add("Price", typeof(decimal));
            
            if(dishes != null)
            {
                foreach(var dish in dishes)
                {
                    dishesDataTable.LoadDataRow(new object[]
                    {
                        dish.Id,
                        dish.Name,
                        dish.DishType.Id, 
                        dish.Description,
                        dish.Price
                    }, 
                    true);
                }
            }

            return dishesDataTable;
        }

        private DataTable CreateMenusDataTable (List<Menu> menus) 
        { 
            DataTable menusDataTable = new DataTable();
            menusDataTable.Columns.Add("Id", typeof(int));
            menusDataTable.Columns.Add("Label", typeof(string));

            if (menus !=null)
            {
                foreach (var menu in menus)
                {
                    menusDataTable.LoadDataRow(new object[]
                    {
                        menu.Id,
                        menu.Name,
                    }, 
                    true);
                }
            }

            return menusDataTable;
        }

        private DataTable CreateMenuFormulasDataTable(List<Menu> menus) 
        {
            DataTable menuFormulasDataTable = new DataTable();
            menuFormulasDataTable.Columns.Add("MenuId", typeof(int));
            menuFormulasDataTable.Columns.Add("FormulaId", typeof(int));

            if (menus != null)
            {
                foreach (var menu in menus)
                {
                    foreach (var formula in menu.Formulas)
                    {
                        menuFormulasDataTable.LoadDataRow(new object[]
                        {
                            menu.Id,
                            formula.Id
                        }, true);
                    }
                }
            }

            return menuFormulasDataTable;
        }

        private DataTable CreateFormulasDataTable(List<Formula> formulas)
        {
            DataTable formulasDataTable = new DataTable();
            formulasDataTable.Columns.Add("Id", typeof(int));
            formulasDataTable.Columns.Add("Description", typeof(string));
            formulasDataTable.Columns.Add("Price", typeof(decimal));

            if (formulas != null)
            {
                foreach (var formula in formulas)
                {
                    formulasDataTable.LoadDataRow(new object[]
                    {
                        formula.Id,
                        formula.Description,
                        formula.Price
                    }, 
                    true);
                }

            }

            return formulasDataTable;
        }

        private DataTable CreateFormulaDishTypeDataTable(List<Formula> formulas)
        {
            DataTable formulaDishTypesDataTable = new DataTable();
            formulaDishTypesDataTable.Columns.Add("FormulaId", typeof(int));
            formulaDishTypesDataTable.Columns.Add("DishTypeId", typeof(int));

            if (formulas != null)
            {
                foreach (var formula in formulas)
                {
                    foreach (var dishtype in formula.DishTypes) 
                    {
                        formulaDishTypesDataTable.LoadDataRow(new object[]
                        {
                            formula.Id,
                            dishtype.Id
                        }, 
                        true);
                    }
                }
            }

            return formulaDishTypesDataTable;
        }

        #endregion
    }
}
