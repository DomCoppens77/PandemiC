using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PandemiC.API.Helper;
using PandemiC.API.Models.API;
using PandemiC.Client.Models;
using PandemiC.Forms;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PandemiC.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
   
    public class CountryController : ControllerBase
    {

        private readonly ICountryService<Country> _clientService;
        public CountryController(ICountryService<Country> clientService)
        {
            _clientService = clientService;
        }
        /// <summary>
        /// Get a List of All Countries registred in the Database
        /// </summary>
        /// <returns>Countries data Registred</returns>
        [HttpGet]
        //[Authorize(Roles = "0,1")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Country> ctry = _clientService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<Country>(HttpStatusCode.OK, null, ctry), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get data of one specified Country registred in the Database according to Country ISO code pass in parameter
        /// </summary>
        /// <param name="iso">Country Code ISO (2 Characters)</param>
        /// <returns>Country data Registred</returns>
        [HttpGet("{iso}")]
        public IActionResult Get([FromRoute] String iso)
        {
            try
            {
                Country ctry = _clientService.Get(iso);
                return ApiControllerHelper.SendOk(this, new ApiResult<Country>(HttpStatusCode.OK, null, ctry), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add country into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Add
        ///     {
        ///        "ISO": "BE",
        ///        "Ctry": "BELGIUM",
        ///        IsEU : false
        ///     }
        ///
        /// </remarks>
        /// <param name="ctry">Ctry Object (ISO,Ctry,IsEU)</param>
        [HttpPost]
        public IActionResult Add([FromBody] CountryForm ctry)
        {
            try
            {
                if (ctry is null) throw new ArgumentNullException("Country Object Empty (ADD)");

                Country ctryo = new Country() {ISO = ctry.ISO, Ctry = ctry.Ctry, IsEU = ctry.IsEU };
                _clientService.Add(ctryo);
                return ApiControllerHelper.SendOk(this, new ApiResult<Country>(HttpStatusCode.OK, null, ctryo), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update country into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "ISO": "BE",
        ///        "Ctry": "BELGIUM",
        ///        IsEU : false
        ///     }
        ///
        /// </remarks>
        /// <param name="ctry">Ctry Object (ISO,Ctry,IsEU)</param>
        [HttpPut]
        public IActionResult Upd([FromBody] CountryForm ctry)
        {
            try
            {
                if (ctry is null) throw new ArgumentNullException("Country Empty (UPD)");
                Country ctryo = new Country() { ISO = ctry.ISO, Ctry = ctry.Ctry, IsEU = ctry.IsEU };
                bool UpdOk = _clientService.Upd(ctryo);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete Country record into table for Admin User(s)
        /// </summary>
        /// <param name="iso">ISO Country Code to Delete</param>
        // DELETE api/<CountryController>/5
        [HttpDelete("{iso}")]
        public IActionResult Del([FromRoute] String iso)
        {
            try
            {
                bool DelOk = _clientService.Del(iso);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        // GET: api/<CountryController>
        /// <summary>
        /// Count how many records use the Country Record
        /// </summary>
        /// /// <param name="iso">ISO Country Code to Delete</param>
        /// <returns>Nbr of Records using that Country </returns>

        [HttpGet("{iso}")]
        public IActionResult Used([FromRoute] string iso)
        {
            try
            {
                int CtryCnt = _clientService.IsUsed(iso);
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, CtryCnt), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
    }
}
