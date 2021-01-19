using PandemiC.Client.Models;
using GM = PandemiC.Global.Models;


namespace PandemiC.Client.Mappers
{
    internal static class UsersServiceMappers
    {
        internal static GM.User ToGlobal(this User e)
        {
            return new GM.User() { Id = e.Id, NatRegNbr = e.NatRegNbr, LastName = e.LastName, FirstName = e.FirstName, Email = e.Email, Passwd = e.Passwd, UserStatus = e.UserStatus, Token = e.Token};
        }

        internal static User ToClient(this GM.User e)
        {
            if (e is null) return null;
            return new User() { Id = e.Id, NatRegNbr = e.NatRegNbr, LastName = e.LastName, FirstName = e.FirstName, Email = e.Email, Passwd = e.Passwd, UserStatus = e.UserStatus, Token = e.Token };
        }
    }
}
