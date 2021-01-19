using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Web.Global.Infrastructure.API.Tools
{
    public class ApiInfo : IApiInfo
    {
        public Uri BaseAddress { get; private set; }

        public ApiInfo(Uri baseAddress)
        {
            BaseAddress = baseAddress;
        }
    }
}
