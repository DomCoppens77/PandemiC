using Microsoft.AspNetCore.Mvc;
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
    [AuthRequired]
    public class TimeLineController : Controller
    {

        private readonly ITimeLineService<TimeLine> _clientService;
        public TimeLineController(ITimeLineService<TimeLine> clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Get a List of All TimeLine Datas registred in the Database
        /// </summary>
        /// <param name="userId">User ID who belong to those data</param>
        /// <returns>TimeLine datas Registred for that User</returns>
        [HttpGet("{userId}")]
        public IActionResult Get([FromRoute] int userId)
        {
            try
            {
                IEnumerable<TimeLine> tl = _clientService.Get(userId);
                return ApiControllerHelper.SendOk(this, new ApiResult<TimeLine>(HttpStatusCode.OK, null, tl), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get a single record of TimeLine registred in the Database
        /// </summary>
        /// <param name="userId">User ID who belong to that data</param>
        /// <param name="id">Id of the record requested</param>
        /// <returns>TimeLine data Registred for that User</returns>
        [HttpGet("{userId}/{id}")]
        public IActionResult Get([FromRoute] int userId, [FromRoute] int id)
        {
            try
            {
                TimeLine tl = _clientService.Get(userId, id);
                return ApiControllerHelper.SendOk(this, new ApiResult<TimeLine>(HttpStatusCode.OK, null, tl), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add TimeLine record into table 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Login
        ///     {
        ///        "userId": 1,
        ///        "restaurantId": 1,
        ///        "dinerDate": "2021-01-19T08:05:05.396Z",
        ///        "nbrGuests": 3
        ///     }
        ///
        /// </remarks>
        /// <param name="userId">User ID who belong to that data</param>
        /// <param name="tl">TimeLine Object</param>
        [HttpPost("{userId}")]
        public IActionResult Add([FromRoute] int userId, [FromBody] TimeLineAddForm tl)
        {
            try
            {
                if (tl is null) throw new ArgumentNullException("TimeLine Object Empty (ADD)");

                TimeLine tlo = new TimeLine() { UserId = tl.UserId, RestaurantId = tl.RestaurantId, DinerDate = tl.DinerDate, NbrGuests = tl.NbrGuests };
                tlo = _clientService.Add(tlo);
                return ApiControllerHelper.SendOk(this, new ApiResult<TimeLine>(HttpStatusCode.OK, null, tlo), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update TimeLine record into table 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "userId": 1,
        ///        "restaurantId": 1,
        ///        "dinerDate": "2021-01-19T08:05:05.396Z",
        ///        "nbrGuests": 3
        ///     }
        ///
        /// </remarks>
        /// <param name="userId">User ID who belong to that data</param>
        /// <param name="id">TimeLine Id</param>
        /// <param name="tl">TimeLine Object</param>
        [HttpPut("{userId}/{id}")]
        public IActionResult Upd([FromRoute] int userId, [FromRoute] int id, [FromBody] TimeLineUpdForm tl)
        {
            try
            {
                if (tl is null) throw new ArgumentNullException("TimeLine Object Empty (UPD)");
                TimeLine tlo = new TimeLine() {Id = id, UserId = tl.UserId, RestaurantId = tl.RestaurantId, DinerDate = tl.DinerDate, NbrGuests = tl.NbrGuests };
                bool UpdOk = _clientService.Upd(id,tlo);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete TimeLine record into table
        /// </summary>
        /// <param name="userId">User ID who belong to that data</param>
        /// <param name="id">TimeLine id to Delete</param>
        [HttpDelete("{userId}/{id}")]
        public IActionResult Del([FromRoute] int userId, [FromRoute] int id)
        {
            try
            {
                bool DelOk = _clientService.Del(userId,id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

    }
}
