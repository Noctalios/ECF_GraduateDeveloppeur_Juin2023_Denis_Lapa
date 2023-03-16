using ECF_Quai_Antique.BLL.Interfaces;
using ECF_Quai_Antique.DAL.Interfaces;
using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserData UserData;

        public UserService(IUserData userData) 
        {
            UserData = userData;
        }

        public void CreateUser(string name, string email, string password, int guest, int roleId, List<Allergie> allergies)
        {
            UserData.CreateUser(name, email, password, guest, roleId, allergies);
        }

        public User GetUser(string email, string password)
        {
            return UserData.GetUser(email, password);
        }
    }
}
