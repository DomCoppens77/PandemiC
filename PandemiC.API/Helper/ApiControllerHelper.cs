using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PandemiC.API.Models.API;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Net;
using System.Security.Authentication;


namespace PandemiC.API.Helper
{
    public class ApiControllerHelper
    {
        public static IActionResult SendOk(ControllerBase instance)
        {
            return SendOk(instance, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IActionResult SendOk(ControllerBase instance, Object o = null, bool creation = false)
        {
            return SendOk(instance, o, creation ? HttpStatusCode.Created : (o != null ? HttpStatusCode.OK : HttpStatusCode.NoContent));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public static IActionResult SendOk(ControllerBase instance, Object o, HttpStatusCode httpStatusCode)
        {
            return instance.StatusCode((int)httpStatusCode, o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="ex"></param>
        /// <returns></returns>

        public static IActionResult SendError(ControllerBase instance, Exception ex)
        {
            switch (ex)
            {
                case AuthenticationException e:
                    return instance.Unauthorized(new ApiResultError(HttpStatusCode.Unauthorized, e));

                case ValidationException e:
                    return instance.BadRequest(new ApiResultError(HttpStatusCode.BadRequest, e));

                case SecurityTokenException e:
                    return instance.StatusCode(498, new ApiResultError(HttpStatusCode.InternalServerError, e));

                case SqlException e: // check if 499 is not taken
                    return instance.StatusCode(499, new ApiResultError(HttpStatusCode.InternalServerError, e));
                default:
                    return instance.StatusCode(500, new ApiResultError(HttpStatusCode.InternalServerError, ex));
            }
        }
    }
}
