using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Web.Global.Infrastructure.API.Tools
{
    public interface IApiInfo
    {
        Uri BaseAddress { get; }
    }
}
