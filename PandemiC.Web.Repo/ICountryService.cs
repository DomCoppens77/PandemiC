using System.Collections.Generic;

namespace PandemiC.Web.Repo
{
    public interface ICountryService<TCtry>
    {
        void Add(TCtry ctry);
        bool Del(string ISO);
        IEnumerable<TCtry> Get();
        TCtry Get(string ISO);
        int IsUsed(string ISO);
        bool Upd(TCtry ctry);
    }
}