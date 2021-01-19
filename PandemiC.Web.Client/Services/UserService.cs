using PandemiC.Web.Client.Mappers;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Repo;
using System.Collections.Generic;
using System.Linq;
using GUser = PandemiC.Web.Global.Models.User;

namespace PandemiC.Web.Client.Services
{
    public class UserService : IUserService<User>
    {
        private readonly IUserService<GUser> _globalService;
        public UserService(IUserService<GUser> globalService)
        {
            _globalService = globalService;
        }

        public IEnumerable<User> Get()
        {
            return _globalService.Get().Select(U => U.ToClient());
        }
    
        public User Get(int id)
        {
            return _globalService.Get(id)?.ToClient();
        }

        public User Add(User user)
        {
            return _globalService.Add(user.ToGlobal()).ToClient();
        }
        public bool Upd(User user)
        {
            return _globalService.Upd(user.ToGlobal());
        }
        public bool UpdLight(User user)
        {
            return _globalService.UpdLight(user.ToGlobal());
        }
        public bool Del(int id)
        {
            return _globalService.Del(id);
        }
        public User Login(string email, string passwd)
        {
            return _globalService.Login(email, passwd).ToClient();
        }
        public User LoginNRN(string natRegNbr, string passwd)
        {
            return _globalService.LoginNRN(natRegNbr, passwd).ToClient();
        }
        public bool EmailIsUsed(string email, int userId)
        {
            return _globalService.EmailIsUsed(email,userId);
        }
        public bool NatRegNbrIsUsed(string natRegNbr, int userId)
        {
            return _globalService.NatRegNbrIsUsed(natRegNbr,userId);
        }
    }
}
