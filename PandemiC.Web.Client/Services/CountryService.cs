using PandemiC.Web.Client.Mappers;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Repo;
using System.Collections.Generic;
using System.Linq;
using GCtry = PandemiC.Web.Global.Models.Country;

namespace PandemiC.Web.Client.Services
{
    public class CountryService : ICountryService<Country>
    {
        private readonly ICountryService<GCtry> _globalService;
        public CountryService(ICountryService<GCtry> globalService)
        {
            _globalService = globalService;
        }

        public IEnumerable<Country> Get()
        {
            return _globalService.Get().Select(C => C.ToClient());
        }

        public Country Get(string ISO)
        {
            return _globalService.Get(ISO)?.ToClient();
        }
        public void Add(Country ctry)
        {
            _globalService.Add(ctry.ToGlobal());
        }
        public bool Upd(Country ctry)
        {
            return _globalService.Upd(ctry.ToGlobal());
        }

        public bool Del(string ISO)
        {
            return _globalService.Del(ISO);
        }

        public int IsUsed(string ISO)
        {
            return _globalService.IsUsed(ISO);
        }
    }
}
