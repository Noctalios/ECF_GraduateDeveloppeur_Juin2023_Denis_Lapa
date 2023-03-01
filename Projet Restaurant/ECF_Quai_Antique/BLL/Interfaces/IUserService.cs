using ECF_Quai_Antique.Entities;

namespace ECF_Quai_Antique.BLL.Interfaces
{
    public interface IUserService
    {
        User GetUser(string email, string password);

        void CreateUser(string email, string password, int guest, int roleId, List<Allergie> allergies);
    }
}
