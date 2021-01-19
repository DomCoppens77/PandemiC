using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PandemiC.API.Models.API
{
    public class ApiResult<TData>
    {
        private int _statusCode;
        private string _message;
        private IEnumerable<TData> _results;
        private int _resultCount;

        public ApiResult(HttpStatusCode statusCode, string message, IEnumerable<TData> results = null)
        {
            StatusCode = (int)statusCode;
            Results = results;
            ResultCount = Results.Count();
            Message = message;
        }

        public ApiResult(HttpStatusCode statusCode, string message, TData result)
        {
            StatusCode = (int)statusCode;
            Results = new List<TData>() { result };
            ResultCount = Results.Count();
            Message = message;
        }

        public int StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public IEnumerable<TData> Results
        {
            get { return _results; }
            set { _results = value; }
        }

        public int ResultCount
        {
            get { return _resultCount; }
            set { _resultCount = value; }
        }
    }

}
