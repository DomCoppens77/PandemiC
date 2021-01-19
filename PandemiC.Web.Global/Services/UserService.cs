using Newtonsoft.Json;
using PandemiC.Web.Global.Forms;
using PandemiC.Web.Global.Infrastructure;
using PandemiC.Web.Global.Models;
using PandemiC.Web.Global.Models.API;
using PandemiC.Web.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PandemiC.Web.Global.Services
{
    public class UserService : IUserService<User>
    {
        private readonly HttpClient _client;
        public UserService(HttpClient client)
        {
            _client = client;
        }

        public IEnumerable<User> Get()
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/user/get").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<User> AUser = JsonConvert.DeserializeObject<ApiResult<User>>(json);
                return AUser.Results;
            }
        }

        public User Get(int id)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/user/get/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<User> AUser = JsonConvert.DeserializeObject<ApiResult<User>>(json);
                return AUser.Results.SingleOrDefault();
            }
        }
        public User Add(User user)
        {
            // Add Global ASP
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new UserAddForm() { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, NatRegNbr = user.NatRegNbr, Passwd = user.Passwd });
                HttpResponseMessage httpResponseMessage = _client.PostAsync($"api/user/add/", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<User> AUser = JsonConvert.DeserializeObject<ApiResult<User>>(json);
                return AUser.Results.SingleOrDefault();
            }
        }
        public bool Upd(User user)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new UserUpdForm() { Id = user.Id, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, NatRegNbr = user.NatRegNbr, UserState = user.UserStatus });
                HttpResponseMessage httpResponseMessage = _client.PutAsync($"api/user/upd/{user.Id}", GetHttpCCl.GetContent(contentJson)).Result;
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
                HttpResponseMessage httpResponseMessage = _client.DeleteAsync($"api/user/del/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> AUser = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)AUser.Results.SingleOrDefault();
            }
        }

        public User Login(string email, string passwd)
        {
            //ApiResultError are = null;
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new { email, passwd });
                HttpResponseMessage httpResponseMessage = _client.PostAsync("api/user/login", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                ApiResult<User> AUser = JsonConvert.DeserializeObject<ApiResult<User>>(json);
                if (AUser.StatusCode < 200 || AUser.StatusCode > 299)
                {
                    //are = JsonConvert.DeserializeObject<ApiResultError>(json);
                    throw new Exception();
                }

                return AUser.Results.SingleOrDefault();
            }
        }

        public bool EmailIsUsed(string email, int userId)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new { email });
                HttpResponseMessage httpResponseMessage = _client.PostAsync($"api/user/EmailIsUsed/{userId}", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> AUser = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)AUser.Results.SingleOrDefault();
            }
        }

        public bool NatRegNbrIsUsed(string natRegNbr, int userId)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new { natRegNbr });
                HttpResponseMessage httpResponseMessage = _client.PostAsync($"api/user/NatRegNbrIsUsed/{userId}", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> AUser = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)AUser.Results.SingleOrDefault();
            }
        }

        public User LoginNRN(string natRegNbr, string passwd)
        {
            //ApiResultError are = null;
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new { natRegNbr, passwd });
                HttpResponseMessage httpResponseMessage = _client.PostAsync("api/user/login2", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                ApiResult<User> AUser = JsonConvert.DeserializeObject<ApiResult<User>>(json);
                if (AUser.StatusCode < 200 || AUser.StatusCode > 299)
                {
                    //are = JsonConvert.DeserializeObject<ApiResultError>(json);
                    throw new Exception();
                }

                return AUser.Results.SingleOrDefault();
            }
        }

        public bool UpdLight(User user)
        {
            using (_client)
            {
                string contentJson = JsonConvert.SerializeObject(new UserUpdLightForm() { Id = user.Id, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, NatRegNbr = user.NatRegNbr });
                HttpResponseMessage httpResponseMessage = _client.PutAsync($"api/user/UpdPersonal/{user.Id}", GetHttpCCl.GetContent(contentJson)).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                ApiResult<bool> AUser = JsonConvert.DeserializeObject<ApiResult<bool>>(json);
                return (bool)AUser.Results.SingleOrDefault();
            }
        }
    }
}
