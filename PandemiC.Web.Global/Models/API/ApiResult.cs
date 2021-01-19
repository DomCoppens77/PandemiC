using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Web.Global.Models.API
{
    public class ApiResult<TData>
    {
        public int StatusCode;
        public string Message;
        public IEnumerable<TData> Results;
        public int ResultCount;
    }
}
