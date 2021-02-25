using DCODatabase.ToolBox.Security;
using DCOToolBox.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PandemiC.API.Helper;
using PandemiC.API.Infrastructure.Security;
using PandemiC.API.Models.API;
using PandemiC.Client.Models;
using PandemiC.Forms;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Net;

namespace PandemiC.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User> _clientService;
        private readonly ITokenService _tokenService;

        private ICryptoRSA _cryptoService;

        public UserController(IUserService<User> clientService, ITokenService tokenService, ICryptoRSA cryptoService)
        {
            _clientService = clientService;
            _tokenService = tokenService;
            _cryptoService = cryptoService;
        }
        /// <summary>
        /// Get a List of All Users registred in the Database
        /// </summary>
        /// <returns>Users data Registred</returns>
        /// <response code="201">Returns List of Users</response>
        [HttpGet]
        [AuthRequired]
        //[SwaggerResponse(HttpStatusCode.OK, typeof(ApiResult<User>), Description = "If everything works fine")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<User> u = _clientService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<User>(HttpStatusCode.OK, null, u), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
        /// <summary>
        /// Get data of one specified Country registred in the Database according to Country ISO code pass in parameter
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Country data Registred</returns>
        /// <response code="201">Returns Specific User Data</response>
        [HttpGet("{id}")]
        //[AuthRequired]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                User u = _clientService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<User>(HttpStatusCode.OK, null, u), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add User record into table 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Add
        ///     {
        ///        "natRegNbr": "771107123456",
        ///        "email": "zecoop@gmail.com",
        ///        "passwd": "Test1234=",
        ///        "firstName": "Dominique",
        ///        "lastName": "Coppens"
        ///     }
        ///
        /// </remarks>/// 
        /// <param name="u">User Object</param>
        /// <response code="201">Returns the newly created item</response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Add([FromBody] UserAddForm u)
        {
            try
            {
                if (u is null) throw new ArgumentNullException("User Object Empty (ADD)");
                
                string testpasswd = _cryptoService.Decrypter(Convert.FromBase64String(u.Passwd));
                // User uo = new User() {Email = u.Email, NatRegNbr = u.NatRegNbr, FirstName = u.FirstName, LastName = u.LastName, Passwd = (Base64.Base64Decode(u.Passwd)};
                User uo = new User() { Email = u.Email, NatRegNbr = u.NatRegNbr, FirstName = u.FirstName, LastName = u.LastName, Passwd = _cryptoService.Decrypter(Convert.FromBase64String(u.Passwd))};
                




                uo = _clientService.Add(uo);
                return ApiControllerHelper.SendOk(this, new ApiResult<User>(HttpStatusCode.OK, null, uo), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update User record into table 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "natRegNbr": "771107123456",
        ///        "email": "zecoop@gmail.com",
        ///        "firstName": "Dominique",
        ///        "lastName": "Coppens"
        ///        "userState": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="id">User Id</param>
        /// <param name="u">User Object</param>
        /// <response code="201">Returns boolean telling if item was Updated</response>
        [HttpPut("{id}")]
        //[AuthRequired]
        public IActionResult Upd(int id, [FromBody] UserUpdForm u)
        {
            try
            {
                if (u is null) throw new ArgumentNullException("User Object Empty (UPD)");
                User uo = new User() {Id= id, Email = u.Email, NatRegNbr = u.NatRegNbr, FirstName = u.FirstName, LastName = u.LastName, UserStatus = u.UserState };
                bool UpdOk = _clientService.Upd(uo);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update personal information of User
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "natRegNbr": "771107123456",     
        ///        "email": "zecoop@gmail.com",
        ///        "firstName": "Dominique",
        ///        "lastName": "Coppens"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">User Id</param>
        /// <param name="u">User Object</param>
        /// <response code="201">Returns boolean telling if item was Updated</response>
        [HttpPut("{id}")]
        //[AuthRequired]
        public IActionResult UpdPersonal(int id, [FromBody] UserUpdLightForm u)
        {
            try
            {
                if (u is null) throw new ArgumentNullException("User Object Empty (UPD)");
                User uo = new User() { Id = id, Email = u.Email, NatRegNbr = u.NatRegNbr, FirstName = u.FirstName, LastName = u.LastName};
                bool UpdOk = _clientService.Upd(uo);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete Restaurant record into table 
        /// </summary>
        /// <param name="id">User Id to Delete</param>
        /// <response code="201">Returns boolean telling if item was Deleted</response>
        [HttpDelete("{id}")]
        //[AuthRequired]
        public IActionResult Del([FromRoute] int id)
        {
            try
            {
                bool DelOk = _clientService.Del(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Login function allow to access Datas (Using Email as Login)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Login
        ///     {
        ///        "Email": "zecoop@gmail.com",
        ///        "Password": "VGVzdDEyMzQ9"
        ///     }
        ///
        /// </remarks>
        /// <example>Tototot</example>
        /// <param name="l">Login Credencial With Password in BASE64 Coding to not transfert Password in clear from Client to API</param>
        /// <returns>User</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginForm l)
        {
            try
            {
                string testpasswd = _cryptoService.Decrypter(Convert.FromBase64String(l.Passwd));
                // User u = _clientService.Login(l.Email, Base64.Base64Decode(l.Passwd));
                User u = _clientService.Login(l.Email, _cryptoService.Decrypter(Convert.FromBase64String(l.Passwd)));
                if (u is not null)
                {
                    u.Token = _tokenService.GenerateToken(u);
                }
                return ApiControllerHelper.SendOk(this, new ApiResult<User>(HttpStatusCode.OK, null, u), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Login function allow to access Datas (Using National Registry Number as Login)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Login
        ///     {
        ///        "NatRegNbr": "19771107139597",
        ///        "Password": "VGVzdDEyMzQ9"
        ///     }
        ///
        /// </remarks>
        /// <example>Tototot</example>
        /// <param name="l">Login Credencial With Password in BASE64 Coding to not transfert Password in clear from Client to API</param>
        /// <returns>User</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login2([FromBody] LoginForm2 l)
        {
            try
            {
                string testpasswd = _cryptoService.Decrypter(Convert.FromBase64String(l.Passwd));
                User u = _clientService.LoginNRN(l.NatRegNbr, Base64.Base64Decode(l.Passwd));
                if (u is not null)
                {
                    u.Token = _tokenService.GenerateToken(u);
                }
                return ApiControllerHelper.SendOk(this, new ApiResult<User>(HttpStatusCode.OK, null, u), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Check if Email is already used in User Table
        /// </summary>
        [HttpPost("{userId}")]
        [AllowAnonymous]
        public IActionResult EmailIsUsed([FromRoute] int userId, [FromBody] EmailForm em)
        {
            try
            {
                bool EmailOK = _clientService.EmailIsUsed(em.Email, userId);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, EmailOK), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Check if NatRegNbr is already used in User Table
        /// </summary>
        [HttpPost("{userId}")]
        [AllowAnonymous]
        public IActionResult NatRegNbrIsUsed([FromRoute] int userId, [FromBody] NatRegNbrForm em)
        {
            try
            {
                bool NatRegNbrOk = _clientService.NatRegNbrIsUsed(em.NatRegNbr, userId);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, NatRegNbrOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
    }
}
