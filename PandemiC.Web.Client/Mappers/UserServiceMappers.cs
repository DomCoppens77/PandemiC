using PandemiC.Web.Client.Models;
using GUser = PandemiC.Web.Global.Models.User;

namespace PandemiC.Web.Client.Mappers
{
    static class UserServiceMappers
    {
        internal static GUser ToGlobal(this User u)
        {
            return new GUser() { Id = u.Id, NatRegNbr = u.NatRegNbr, LastName = u.LastName, FirstName = u.FirstName, Email = u.Email, Passwd = u.Passwd, UserStatus = u.UserStatus, Token = u.Token };
        }

        internal static User ToClient(this GUser u)
        {
            if (u is null) return null;
            return new User() { Id = u.Id, NatRegNbr = u.NatRegNbr, LastName = u.LastName, FirstName = u.FirstName, Email = u.Email, Passwd = u.Passwd, UserStatus = u.UserStatus, Token = u.Token };
        }
    }
}
