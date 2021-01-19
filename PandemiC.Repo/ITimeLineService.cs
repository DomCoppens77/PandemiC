using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Repo
{
    public interface ITimeLineService<TTimeLine>
    {
        IEnumerable<TTimeLine> Get(int userId);

        TTimeLine Get(int userId,int id);

        TTimeLine Add(TTimeLine tl);

        bool Upd(int id, TTimeLine tl);

        bool Del(int userId,int id);
    }
}
