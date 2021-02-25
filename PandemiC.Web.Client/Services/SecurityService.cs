using PandemiC.Web.Client.Mappers;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Repo;
using System;
using GKeyInfo = PandemiC.Web.Global.Models.KeyInfo;

namespace PandemiC.Web.Client.Services
{
    public class SecurityService : ISecurityService<KeyInfo>
    {
        private readonly ISecurityService<GKeyInfo> _globalService;
        public SecurityService(ISecurityService<GKeyInfo> globalService)
        {
            _globalService = globalService;
        }

        public KeyInfo Get()
        {
            return _globalService.Get()?.ToClient();
        }
    }
}
