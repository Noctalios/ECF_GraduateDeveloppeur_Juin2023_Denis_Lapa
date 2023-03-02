using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.DAL.Interfaces
{
    public interface IUserData
    {
        User GetUser(string email, string password);

        void CreateUser(string email, string password, int guest, int roleId, List<Allergie> allergies);
    }
}
