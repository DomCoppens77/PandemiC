using System.Net.Http;
using System.Net.Http.Headers;

namespace PandemiC.Web.Global.Infrastructure
{
    static class GetHttpCCl
    {
        internal static HttpContent GetContent(string str)
        {
            HttpContent httpContent = new StringContent(str);
            httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            return httpContent;
        }
    }
}
