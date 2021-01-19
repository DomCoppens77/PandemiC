using Newtonsoft.Json;
using PandemiC.Web.Global.Forms;
using PandemiC.Web.Global.Infrastructure;
using PandemiC.Web.Global.Models;
using PandemiC.Web.Global.Models.API;
using PandemiC.Web.Repo;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PandemiC.Web.Global.Services
{
    public class RestaurantService : IRestaurantService<Restaurant>
    {
        private readonly HttpClient _client;
        public RestaurantService(HttpClient client)
        {
            _client = client;
        }
        public IEnumerable<Restaurant> Get()
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/Restaurant/get").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<Restaurant> ARestaurant = JsonConvert.DeserializeObject<ApiResult<Restaurant>>(json);
                return ARestaurant.Results;
            }
        }

        public Restaurant Get(int id)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/Restaurant/get/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<Restaurant> ARestaurant = JsonConvert.DeserializeObject<ApiResult<Restaurant>>(json);
                return ARestaurant.Results.SingleOrDefault();
            }
        }

        public Restaurant Add(Restaurant r)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new RestaurantFormAdd() { Name = r.Name, Address1 = r.Address1, Address2 = r.Address2, Zip = r.Zip, City = r.City, Country = r.Country, Email = r.Email, VAT = r.VAT, Closed = r.Closed });

                HttpResponseMessage httpResponseMessage = _client.PostAsync($"api/Restaurant/add/", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<Restaurant> AResto = JsonConvert.DeserializeObject<ApiResult<Restaurant>>(json);
                return AResto.Results.SingleOrDefault();
            }
        }

        public bool Upd(Restaurant r)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new RestaurantFormUpd() { Id = r.Id, Name = r.Name, Address1 = r.Address1, Address2 = r.Address2, Zip = r.Zip, City = r.City, Country = r.Country, Email = r.Email, VAT = r.VAT, Closed = r.Closed });

                HttpResponseMessage httpResponseMessage = _client.PutAsync($"api/Restaurant/upd/", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> AUser = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)AUser.Results.SingleOrDefault();
            }
        }

        public bool Del(int id)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.DeleteAsync($"api/Restaurant/del/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> ARestaurant = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)ARestaurant.Results.SingleOrDefault();
            }
        }

        public int IsUsed(int id)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/Restaurant/IsUsed/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<int> ARestaurant = JsonConvert.DeserializeObject<ApiResult<int>>(json);
                return (int)ARestaurant.Results.SingleOrDefault();
            }
        }

        public bool VATIsUsed(string vat, int id)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new VatCheckForm() { VAT = vat });
                HttpResponseMessage httpResponseMessage = _client.PostAsync($"api/Restaurant/VATIsUsed/{id}", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> ARestaurant = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)ARestaurant.Results.SingleOrDefault();
            }
        }

    }
}
