using Microsoft.AspNetCore.Mvc;
using PandemiC.API.Helper;
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
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService<Restaurant> _clientService;
        public RestaurantController(IRestaurantService<Restaurant> clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Get a List of All Restaurants registred in the Database
        /// </summary>
        /// <returns>Restaurants data Registred</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Restaurant> resto = _clientService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<Restaurant>(HttpStatusCode.OK, null, resto), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get data of one specified Restaurant registred in the Database according to ID pass in parameter
        /// </summary>
        /// <param name="id">Restaurant Id</param>
        /// <returns>Restaurant data Registred</returns>
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                Restaurant resto = _clientService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<Restaurant>(HttpStatusCode.OK, null, resto), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add Restaurant record into table 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Add
        ///     {
        ///       name: "string",
        ///       vat: "string",
        ///       address1: "string",
        ///       address2: "string",
        ///       zip: "string",
        ///       city: "string",
        ///       country: "string",
        ///       email: "string",
        ///       closed: true
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Restaurant Id</param>
        /// <param name="resto">Restaurant Object</param>
        [HttpPost]
        public IActionResult Add([FromBody] RestaurantFormAdd resto)
        {
            try
            {
                if (resto is null) throw new ArgumentNullException("Restaurant Object Empty (ADD)");

                Restaurant restoo = new Restaurant() { VAT = resto.VAT, Name = resto.Name, Address1 = resto.Address1, Address2 = resto.Address2, Zip = resto.Zip, City = resto.City, Country = resto.Country, Email = resto.Email, Closed = resto.Closed };
                restoo = _clientService.Add(restoo);
                return ApiControllerHelper.SendOk(this, new ApiResult<Restaurant>(HttpStatusCode.OK, null, restoo), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update Restaurant record into table 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///       name: "string",
        ///       vat: "string",
        ///       address1: "string",
        ///       address2: "string",
        ///       zip: "string",
        ///       city: "string",
        ///       country: "string",
        ///       email: "string",
        ///       closed: true
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Restaurant Id</param>
        /// <param name="resto">Restaurant Object</param>
        [HttpPut("{id}")]
        public IActionResult Upd(int id, [FromBody] RestaurantFormUpd resto)
        {
            try
            {
                if (resto is null) throw new ArgumentNullException("Restaurant Object Empty (UPD)");
                Restaurant restoo = new Restaurant() { Id = id, VAT = resto.VAT, Name = resto.Name, Address1 = resto.Address1, Address2 = resto.Address2, Zip = resto.Zip, City = resto.City, Country = resto.Country, Email = resto.Email, Closed = resto.Closed };
                bool UpdOk = _clientService.Upd(restoo);
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
        /// <param name="id">Restaurant Id</param>
        [HttpDelete("{id}")]
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
        /// Check How Many Time Line Records are using that restuatant
        /// </summary>
        [HttpPost("{id}")]
        public IActionResult IsUsed([FromRoute] int id)
        {
            try
            {
                int NbrRecUsed = _clientService.IsUsed(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, NbrRecUsed), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Check if VAT is already used in Restaurant Table
        /// </summary>
        [HttpPost("{id}")]
        public IActionResult VATIsUsed([FromRoute] int id, [FromBody] VatCheckForm vat)
        {
            try
            {
                bool NatRegNbrOk = _clientService.VATIsUsed(vat.VAT,id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, NatRegNbrOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);

            }
        }

    } 
}
