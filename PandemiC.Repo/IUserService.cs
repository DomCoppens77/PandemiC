using System.Collections.Generic;

namespace PandemiC.Repo
{
    public interface IUserService<TUser>
    {
        IEnumerable<TUser> Get();

        TUser Get(int id);

        TUser Add(TUser user);

        bool Upd(TUser user);

        bool UpdLight(TUser user);

        bool Del(int id);

        TUser Login(string email, string passwd);

        TUser LoginNRN(string natRegNbr, string passwd);

        bool EmailIsUsed(string email, int userId);
        bool NatRegNbrIsUsed(string natRegNbr, int userId);



    }
}
