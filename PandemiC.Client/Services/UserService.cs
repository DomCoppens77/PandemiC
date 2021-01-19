using PandemiC.Client.Mappers;
using PandemiC.Client.Models;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GUser = PandemiC.Global.Models.User;

namespace PandemiC.Client.Services
{
    public class UserService : IUserService<User>
    {
        private readonly string where = "CU";
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
            if (user is null) throw new NullReferenceException($"User Data empty ({where}) (ADD)");
            return _globalService.Add(user.ToGlobal()).ToClient();

        }
        public bool Upd(User user)
        {
            if (user is null) throw new NullReferenceException($"User Data empty ({where}) (UPD)");
            return _globalService.Upd(user.ToGlobal());
        }
        public bool UpdLight(User user)
        {
            if (user is null) throw new NullReferenceException($"User Data empty ({where}) (UPDLGHT)");
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
