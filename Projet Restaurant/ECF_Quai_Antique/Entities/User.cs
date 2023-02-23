namespace ECF_Quai_Antique.Entities
{
    public class User
    {
        private int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        private int? Guest { get; set; }

        private List<Allergie> Allergies { get; set; }

        public User(int id, string email, string password, int guest, List<Allergie> allergies, string role) 
        {
            Id = id;
            Email = email;
            Password = password;
            Guest = guest;
            Allergies = allergies;
            Role = role;
        }
    }
}