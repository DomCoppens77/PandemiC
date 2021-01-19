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
    public class CountryService : ICountryService<Country>
    {
        private readonly HttpClient _client;
        public CountryService(HttpClient client)
        {
            _client = client;
        }

        public IEnumerable<Country> Get()
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/country/get").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<Country> ACountry = JsonConvert.DeserializeObject<ApiResult<Country>>(json);
                return ACountry.Results;
            }
        }

        public Country Get(string ISO)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/country/get/{ISO}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<Country> ACountry = JsonConvert.DeserializeObject<ApiResult<Country>>(json);
                return ACountry.Results.SingleOrDefault();
            }
        }

        public void Add(Country ctry)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new CountryForm() { ISO = ctry.ISO, Ctry = ctry.Ctry, IsEU = ctry.IsEU });
                HttpResponseMessage httpResponseMessage = _client.PostAsync($"api/country/add/", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }

        public bool Upd(Country ctry)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new CountryForm() { ISO = ctry.ISO, Ctry = ctry.Ctry, IsEU = ctry.IsEU });
                HttpResponseMessage httpResponseMessage = _client.PutAsync($"api/country/upd/", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> AUser = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)AUser.Results.SingleOrDefault();
            }
        }
        public bool Del(string ISO)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.DeleteAsync($"api/country/del/{ISO}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> ACountry = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)ACountry.Results.SingleOrDefault();
            }
        }

        public int IsUsed(string ISO)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/country/IsUsed/{ISO}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<int> ACountry = JsonConvert.DeserializeObject<ApiResult<int>>(json);
                return (int)ACountry.Results.SingleOrDefault();
            }
        }
    }
}
