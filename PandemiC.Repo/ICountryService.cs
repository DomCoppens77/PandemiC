using System.Collections.Generic;

namespace PandemiC.Repo
{ 
    public interface ICountryService<TCountry>
    {
        IEnumerable<TCountry> Get();

        TCountry Get(string ISO);

        void Add(TCountry ctry);

        bool Upd(TCountry ctry);

        bool Del(string ISO);

        int IsUsed(string ISO);
    }
}
