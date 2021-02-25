using DCOToolBox.Cryptography;
using Microsoft.AspNetCore.Mvc;
using PandemiC.API.Models;
using System;

namespace PandemiC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private ICryptoRSA _cryptoService;

        public SecurityController(ICryptoRSA cryptoService)
        {
            _cryptoService = cryptoService;
        }

        [HttpGet]
        public KeyInfo Get()
        {
            KeyInfo keyInfo = new KeyInfo() { PublicKey = Convert.ToBase64String(_cryptoService.BinaryPublicKey) };
            return keyInfo;
        }
    }
}
