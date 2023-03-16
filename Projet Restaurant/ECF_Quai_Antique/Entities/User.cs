namespace ECF_Quai_Antique.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? Guest { get; set; }

        public Role Role { get; set; }

        public List<Allergie>? Allergies { get; set; }

        public User() { }

        public User(int id, string name, string email, string password, int? guest, List<Allergie> allergies, Role role) 
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Guest = guest ?? null;
            Allergies = allergies;
            Role = role;
        }
    }
}