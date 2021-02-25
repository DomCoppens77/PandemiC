using DCOToolBox.Cryptography;
using Microsoft.AspNetCore.Mvc.Filters;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Client.Services;
using PandemiC.Web.Repo;
using System;

namespace PandemiC.Web.Attribute
{
    public class GetPublicKeyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ISecurityService<KeyInfo> securityRepository = (ISecurityService<KeyInfo>)context.HttpContext.RequestServices.GetService(typeof(ISecurityService<KeyInfo>));
            ICryptoRSA cryptoRSA = (ICryptoRSA)context.HttpContext.RequestServices.GetService(typeof(ICryptoRSA));
            KeyInfo keyInfo = securityRepository.Get();
            cryptoRSA.ImportBinaryKeys(Convert.FromBase64String(keyInfo.PublicKey));
        }
    }
}

