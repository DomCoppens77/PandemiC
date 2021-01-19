using PandemiC.Client.Mappers;
using PandemiC.Client.Models;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GTL = PandemiC.Global.Models.TimeLine;

namespace PandemiC.Client.Services
{
    public class TimeLineService : ITimeLineService<TimeLine>
    {
        private readonly string where = "CTL";
        private readonly ITimeLineService<GTL> _globalService;

        public TimeLineService(ITimeLineService<GTL> globalService)
        {
            _globalService = globalService;
        }
        public IEnumerable<TimeLine> Get(int userId)
        {
            return _globalService.Get(userId).Select(U => U.ToClient()); 
        }

        public TimeLine Get(int userId, int id)
        {
            return _globalService.Get(userId, id)?.ToClient(); 
        }
        public TimeLine Add(TimeLine tl)
        {
            if (tl is null) throw new NullReferenceException($"TimeLine Data empty ({where}) (ADD)");
            return _globalService.Add(tl.ToGlobal()).ToClient();
        }
        public bool Upd(int id, TimeLine tl)
        {
            if (tl is null) throw new NullReferenceException($"TimeLine Data empty ({where}) (UPD)");
            return _globalService.Upd(id,tl.ToGlobal());
        }
        public bool Del(int userId,int id)
        {
            return _globalService.Del(userId, id);
        }
    }
}
