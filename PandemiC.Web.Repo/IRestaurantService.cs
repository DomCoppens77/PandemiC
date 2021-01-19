using System.Collections.Generic;

namespace PandemiC.Web.Repo
{
    public interface IRestaurantService<TResto>
    {
        TResto Add(TResto r);
        bool Del(int id);
        IEnumerable<TResto> Get();
        TResto Get(int id);
        int IsUsed(int id);
        bool Upd(TResto r);
        bool VATIsUsed(string vat, int id);
    }
}