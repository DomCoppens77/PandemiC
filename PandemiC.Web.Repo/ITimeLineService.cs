using System.Collections.Generic;

namespace PandemiC.Web.Repo
{
    public interface ITimeLineService<TL>
    {
        TL Add(TL tl);
        bool Del(int userId, int id);
        IEnumerable<TL> Get(int userId);
        TL Get(int userId, int id);
        bool Upd(int id, TL tl);
    }
}