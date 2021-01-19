using PandemiC.Client.Mappers;
using PandemiC.Client.Models;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GCtry = PandemiC.Global.Models.Country;

namespace PandemiC.Client.Services
{
    public class CountryService : ICountryService<Country>
    {
        private readonly string where = "CCTRY";
        private readonly ICountryService<GCtry> _globalService;

        public CountryService(ICountryService<GCtry> globalService)
        {
            _globalService = globalService;
        }
        public IEnumerable<Country> Get()
        {
            return _globalService.Get().Select(U => U.ToClient());
        }

        public Country Get(string ISO)
        {
            return _globalService.Get(ISO)?.ToClient();
        }

        public void Add(Country ctry)
        {
            if (ctry is null) throw new NullReferenceException($"Country Data empty ({where}) (ADD)");
            _globalService.Add(ctry.ToGlobal());
        }
        public bool Upd(Country ctry)
        {
            if (ctry is null) throw new NullReferenceException($"Country Data empty ({where}) (ADD)");
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
