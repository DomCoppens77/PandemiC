using PandemiC.Web.Client.Mappers;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Repo;
using System.Collections.Generic;
using System.Linq;
using GResto = PandemiC.Web.Global.Models.Restaurant;

namespace PandemiC.Web.Client.Services
{
    public class RestaurantService : IRestaurantService<Restaurant>
    {
        private readonly IRestaurantService<GResto> _globalService;
        public RestaurantService(IRestaurantService<GResto> globalService)
        {
            _globalService = globalService;
        }

        public IEnumerable<Restaurant> Get()
        {
            return _globalService.Get().Select(C => C.ToClient());
        }

        public Restaurant Get(int id)
        {
            return _globalService.Get(id)?.ToClient();
        }
        public Restaurant Add(Restaurant restaurant)
        {
            return _globalService.Add(restaurant.ToGlobal()).ToClient();
        }
        public bool Upd(Restaurant restaurant)
        {
            return _globalService.Upd(restaurant.ToGlobal());
        }

        public bool Del(int id)
        {
            return _globalService.Del(id);
        }

        public int IsUsed(int id)
        {
            return _globalService.IsUsed(id);
        }

        public bool VATIsUsed(string vat, int id)
        {
            return _globalService.VATIsUsed(vat,id);
        }
    }
}
