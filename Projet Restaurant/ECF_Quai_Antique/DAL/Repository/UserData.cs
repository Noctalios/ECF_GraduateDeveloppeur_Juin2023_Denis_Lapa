﻿using ECF_Quai_Antique.DAL.Interfaces;
using ECF_Quai_Antique.Entities;
using Microsoft.Data.SqlClient;

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
                    //Fill parameter @AllergiesTableType with allergies.Name

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
    }
}