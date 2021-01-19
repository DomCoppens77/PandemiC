using System.Collections.Generic;

namespace PandemiC.Web.Repo
{
    public interface IUserService<TUser>
    {
        TUser Add(TUser user);
        bool Del(int id);
        
        IEnumerable<TUser> Get();
        TUser Get(int id);
        TUser Login(string email, string passwd);
        bool NatRegNbrIsUsed(string natRegNbr, int userId);
        bool EmailIsUsed(string email, int userId);
        bool Upd(TUser user);
        
        TUser LoginNRN(string natRegNbr, string passwd);
        bool UpdLight(TUser user);
    }
}