using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Web.Global.Infrastructure.API.Tools
{
    public class ApiRequester
    {
        private HttpClient _client;

        public ApiRequester(string baseAdress)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAdress);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            using (HttpResponseMessage message = _client.GetAsync(uri).Result)
            {
                string json = await message.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(json);
            }
        }
                public async Task PostAsync<TBody>(TBody body, string uri)
        {
            string jsonBody = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = _client.PostAsync(uri, content).Result)
            {
                await message.Content.ReadAsStringAsync();
            }
        }



        public async Task PutAsync<TBody>(TBody body, string uri)
        {
            string jsonBody = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = _client.PutAsync(uri, content).Result)
            {
                await message.Content.ReadAsStringAsync();
            }
        }



        public async Task DeleteAsync(int id, string uri)
        {
            using (HttpResponseMessage message = _client.DeleteAsync(uri + id).Result)
            {
                await message.Content.ReadAsStringAsync();
            }
        }



        public async Task DeleteAsync(string uri)
        {
            using (HttpResponseMessage message = _client.DeleteAsync(uri).Result)
            {
                await message.Content.ReadAsStringAsync();
            }
        }



        public string Get(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentException(nameof(uri) + " : Cannot be empty or null");
            HttpResponseMessage message = _client.GetAsync(uri).Result;
            return message.Content.ReadAsStringAsync().Result;
        }



        public string Post<TBody>(TBody body, string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentException(nameof(uri) + " : Cannot be empty or null");
            if (body == null)
                throw new ArgumentException(nameof(body) + " : Cannot be null");
            HttpResponseMessage message = _client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")).Result;
            return message.Content.ReadAsStringAsync().Result;
        }



        public string Put<TBody>(TBody body, string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentException(nameof(uri) + " : Cannot be empty or null");
            if (body == null)
                throw new ArgumentException(nameof(body) + " : Cannot be null");
            HttpResponseMessage message = _client.PutAsync(uri, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")).Result;
            return message.Content.ReadAsStringAsync().Result;
        }



        public string Delete(int id, string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentException(nameof(uri) + " : Cannot be empty or null");
            HttpResponseMessage message = _client.DeleteAsync(uri + id).Result;
            return message.Content.ReadAsStringAsync().Result;
        }



        public string Delete(string uri)
        {
            HttpResponseMessage message = _client.DeleteAsync(uri).Result;
            return message.Content.ReadAsStringAsync().Result;
        }
    }
}
