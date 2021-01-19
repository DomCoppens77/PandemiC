using PandemiC.Client.Mappers;
using PandemiC.Client.Models;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GResto = PandemiC.Global.Models.Restaurant;

namespace PandemiC.Client.Services
{
    public class RestaurantService : IRestaurantService<Restaurant>
    {
        private readonly string where = "CResto";
        private readonly IRestaurantService<GResto> _globalService;

        public RestaurantService(IRestaurantService<GResto> globalService)
        {
            _globalService = globalService;
        }
        public IEnumerable<Restaurant> Get()
        {
            return _globalService.Get().Select(U => U.ToClient()); 
        }

        public Restaurant Get(int id)
        {
            return _globalService.Get(id)?.ToClient();
        }
        public Restaurant Add(Restaurant restaurant)
        {
            if (restaurant is null) throw new NullReferenceException($"Restaurant Data empty ({where}) (ADD)");
            return _globalService.Add(restaurant.ToGlobal()).ToClient();
        }

        public bool Upd(Restaurant restaurant)
        {
            if (restaurant is null) throw new NullReferenceException($"Restaurant Data empty ({where})(UPD)");
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
