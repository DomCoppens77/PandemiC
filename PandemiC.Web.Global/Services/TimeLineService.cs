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
    public class TimeLineService : ITimeLineService<TimeLine>
    {
        private readonly HttpClient _client;
        public TimeLineService(HttpClient client)
        {
            _client = client;
        }

        public IEnumerable<TimeLine> Get(int userId)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/TimeLine/get/{userId}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<TimeLine> ATL = JsonConvert.DeserializeObject<ApiResult<TimeLine>>(json);
                return ATL.Results;
            }
        }

        public TimeLine Get(int userId, int id)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/TimeLine/get/{userId}/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<TimeLine> ATL = JsonConvert.DeserializeObject<ApiResult<TimeLine>>(json);
                return ATL.Results.SingleOrDefault();
            }
        }
        public TimeLine Add(TimeLine tl)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new TimeLineAddForm() { DinerDate = tl.DinerDate, NbrGuests = tl.NbrGuests, RestaurantId = tl.RestaurantId, UserId = tl.UserId });
                HttpResponseMessage httpResponseMessage = _client.PostAsync($"api/TimeLine/add/{tl.UserId}", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<TimeLine> ATL = JsonConvert.DeserializeObject<ApiResult<TimeLine>>(json);
                return ATL.Results.SingleOrDefault();
            }
        }
        public bool Upd(int id, TimeLine tl)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new TimeLineUpdForm() { Id = tl.Id, DinerDate = tl.DinerDate, NbrGuests = tl.NbrGuests, RestaurantId = tl.RestaurantId, UserId = tl.UserId });
                HttpResponseMessage httpResponseMessage = _client.PutAsync($"api/TimeLine/upd/{tl.UserId}/{id}", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> ATL = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)ATL.Results.SingleOrDefault();
            }
        }

        public bool Del(int userId, int id)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.DeleteAsync($"api/TimeLine/del/{userId}/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> ACountry = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)ACountry.Results.SingleOrDefault();
            }
        }

    }
}
