using Newtonsoft.Json;
using PandemiC.Web.Global.Models;
using PandemiC.Web.Repo;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace PandemiC.Web.Global.Services
{

    public class SecurityService : ISecurityService<KeyInfo>
    {

        private readonly HttpClient _httpClient;

        //public SecurityService(HttpClient client)
        //{
        //    _httpClient = client;
        //}

        public SecurityService(Uri baseAddress)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                //obligatoire si on lance l'api en selfhost (console) .Default
              //  SslProtocols = SslProtocols.Tls12
            };

            handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = baseAddress;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public KeyInfo Get()
        {
            Task<HttpResponseMessage> httpResponseMessageTask = _httpClient.GetAsync("api/security");
            httpResponseMessageTask.Wait();
            HttpResponseMessage httpResponseMessage = httpResponseMessageTask.Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<KeyInfo>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }
    }
}
