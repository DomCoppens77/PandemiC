using PandemiC.Web.Client.Mappers;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Repo;
using System.Collections.Generic;
using System.Linq;
using GTL = PandemiC.Web.Global.Models.TimeLine;

namespace PandemiC.Web.Client.Services
{
    public class TimeLineService : ITimeLineService<TimeLine>
    {
        private readonly ITimeLineService<GTL> _globalService;
        public TimeLineService(ITimeLineService<GTL> globalService)
        {
            _globalService = globalService;
        }
        public IEnumerable<TimeLine> Get(int userId)
        {
            return _globalService.Get(userId).Select(TL => TL.ToClient());
        }

        public TimeLine Get(int userId,int id)
        {
            return _globalService.Get(userId,id)?.ToClient();
        }
        public TimeLine Add(TimeLine tl)
        {
            return _globalService.Add(tl.ToGlobal()).ToClient();
        }
        public bool Upd(int id,TimeLine tl)
        {
            return _globalService.Upd(id,tl.ToGlobal());
        }
        public bool Del(int userId, int id)
        {
            return _globalService.Del(userId, id);
        }
    }
}
