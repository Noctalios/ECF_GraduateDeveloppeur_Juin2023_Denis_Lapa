using Microsoft.Data.SqlClient;
using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.DAL
{
    public class UserData 
    {
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
                            Console.WriteLine($"Id : {CurrentUser.Id}");
                            Console.WriteLine($"Email : {CurrentUser.Email}");
                            Console.WriteLine($"Password : {CurrentUser.Password}");
                            Console.WriteLine($"Guest : {CurrentUser.Guest}");
                            Console.WriteLine($"RoleId : {CurrentUser.Role.Id}");
                            Console.WriteLine($"RoleLabel : {CurrentUser.Role.Label}");
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

        public void CreateUser(string email, string password, int guest, int roleId, List<Allergie> allergies)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.ConnectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Restaurant;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
            string sql = "EXEC [dbo].[CreateUser] @Email, @Password, @Guest, @RoleId, @Allergens ;";

            using (SqlConnection  connection = new SqlConnection(builder.ConnectionString)) 
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Guest", guest);
                command.Parameters.AddWithValue("@RoleId", roleId);
                foreach (var allergie in allergies) 
                {
                    //Fill parameter AllergiesTableType with allergies.Name

                }

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();


            }
        }
    }
}
