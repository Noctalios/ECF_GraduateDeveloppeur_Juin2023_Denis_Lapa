using ECF_Quai_Antique.DAL.Interfaces;
using ECF_Quai_Antique.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;

namespace ECF_Quai_Antique.DAL.Repository
{
    public class UserData : IUserData
    {
        #region CREATE

        public void CreateUser(string email, string password, int guest, int roleId, List<Allergie> allergies)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[CreateUser] @Email, @Password, @Guest, @RoleId, @Allergens ;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Guest", guest);
                    command.Parameters.AddWithValue("@RoleId", roleId);
                    // Parameter Allergens
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
                User CurrentUser = new User();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                string sql = "EXEC [dbo].[GetUser] @Email, @Password ;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CurrentUser.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            CurrentUser.Email = reader.GetString(reader.GetOrdinal("Email"));
                            CurrentUser.Password = reader.GetString(reader.GetOrdinal("Password"));
                            CurrentUser.Guest = reader.IsDBNull(reader.GetOrdinal("Guest")) ? null : reader.GetInt32(reader.GetOrdinal("Guest"));
                            CurrentUser.Role = new Role(reader.GetInt32(reader.GetOrdinal("Id")), reader.GetString(reader.GetOrdinal("Label")));
                            
                            //CurrentUser.allergies a garnir mais c'est une liste
                        }
                    }

                    connection.Close();
                }

                return CurrentUser;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        #endregion

        internal DataTable CreateAllergiesDataTable (List<Allergie> allergies)
        {
            var allergiesDataTable = new DataTable();
            allergiesDataTable.Columns.Add("Label", typeof(string));

            if(allergies != null) 
            {
                foreach (var allergie in allergies) 
                {
                    allergiesDataTable.LoadDataRow(new object[]
                    {
                        allergie.Name,
                    }, true);
                }
            }
            return allergiesDataTable;
        }
    }
}
