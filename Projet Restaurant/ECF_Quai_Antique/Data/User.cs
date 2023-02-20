namespace ECF_Quai_Antique.Data
{
    public class User
    {
        private int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        private int? Guest { get; set; }

        public User(string email, string password, int guest) 
        {
            this.Email = email;
            this.Password = password;
            this.Guest = guest;
        }
    }
}