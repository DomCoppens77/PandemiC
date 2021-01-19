using System.Collections.Generic;

namespace PandemiC.Repo
{
    public interface IRestaurantService<TRestaurant>
    {
        IEnumerable<TRestaurant> Get();

        TRestaurant Get(int id);

        TRestaurant Add(TRestaurant restaurant);

        bool Upd(TRestaurant restaurant);

        bool Del(int id);

        int IsUsed(int id);
        bool VATIsUsed(string vat, int id);
    }
}
