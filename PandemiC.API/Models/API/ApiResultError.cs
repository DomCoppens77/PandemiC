using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PandemiC.API.Models.API
{
    public class ApiResultError
    {
        private int _statusCode;
        private string _errorMessage;

        public ApiResultError(HttpStatusCode statusCode, Exception e)
        {
            StatusCode = (int)statusCode;
            ErrorMessage = e.Message;
        }
        public int StatusCode
        {
            get => _statusCode;
            set { _statusCode = value; }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; }
        }
    }
}
