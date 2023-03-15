using ECF_Quai_Antique.DAL.Interfaces;
using ECF_Quai_Antique.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace ECF_Quai_Antique.DAL.Repository
{
    public class UserData : IUserData
    {
        private IConfiguration Configuration;

        public UserData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private string GetConnexionString()
        {
            return Configuration.GetConnectionString("DefaultConnection");
        }

        #region CREATE

        public void CreateUser(string email, string password, int guest, int roleId, List<Allergie> allergies)
        {
            try
            {
                string sql = "EXEC [dbo].[CreateUser] @Email, @Password, @Guest, @RoleId, @Allergens ;";

                using (SqlConnection connection = new SqlConnection(GetConnexionString()))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Guest", guest);
                    command.Parameters.AddWithValue("@RoleId", roleId);

                    // Parameter @Allergens
                    SqlParameter parameter = command.Parameters.AddWithValue("@Allergens", CreateAllergiesDataTable(allergies));
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.AllergiesTableType";
 
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

        #region READ

        public User GetUser(string email, string password)
        {
            try
            {
                Dictionary<int, User> result = new Dictionary<int, User>();

                string sql = "EXEC [dbo].[GetUser] @Emai4l, @Password ;";

                using (SqlConnection connection = new SqlConnection(GetConnexionString()))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(reader.GetOrdinal("AllergieId")))
                            {
                                User newUser = new User()
                                {
                                    Id = reader.GetInt32("Id"),
                                    Email = reader.GetString("Email"),
                                    Password = reader.GetString("Password"),
                                    Guest = reader.IsDBNull(reader.GetInt32("Guest")) ? null : reader.GetInt32(reader.GetOrdinal("Guest")),
                                    Role = new Role(reader.GetInt32("RoleId"), reader.GetString("RoleLabel")),
                                };
                                result.Add(reader.GetInt32("Id"), newUser);
                            }
                            else 
                            {
                                if (result.TryGetValue(reader.GetInt32("Id"), out User User))
                                {
                                    User.Allergies.Add(new Allergie()
                                    {
                                        Id = reader.GetInt32("AllergieId"),
                                        Name = reader.GetString("AllergieLabel"),
                                    });
                                }
                                else
                                {
                                    User newUser = new User()
                                    {
                                        Id = reader.GetInt32("Id"),
                                        Email = reader.GetString("Email"),
                                        Password = reader.GetString("Password"),
                                        Guest = reader.IsDBNull(reader.GetInt32("Guest")) ? null : reader.GetInt32(reader.GetOrdinal("Guest")),
                                        Role = new Role(reader.GetInt32("RoleId"), reader.GetString("RoleLabel")),
                                        Allergies = new List<Allergie>()
                                        {
                                            new Allergie()
                                            {
                                                Id = reader.GetInt32("AllergieId"),
                                                Name = reader.GetString("AllergieLabel"),
                                            }
                                        }
                                    };
                                    result.Add(reader.GetInt32("Id"), newUser);
                                }
                            }
                        }
                    }

                    connection.Close();
                }
                return result.Values.FirstOrDefault();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        #endregion

        #region DataTable
        
        private DataTable CreateAllergiesDataTable (List<Allergie> allergies)
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

        #endregion
    }
}
