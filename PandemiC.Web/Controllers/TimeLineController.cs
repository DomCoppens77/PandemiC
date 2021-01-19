using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Infrastructure;
using PandemiC.Web.Models.Forms.TimeLine;
using PandemiC.Web.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemiC.Web.Controllers
{
    public class TimeLineController : Controller
    {

        private readonly ITimeLineService<TimeLine> _timeLineService;
        private readonly IRestaurantService<Restaurant> _restaurantService;
        private readonly ISessionManager _sessionManager;

        public TimeLineController(ITimeLineService<TimeLine> timeLineService, ISessionManager sessionManager, IRestaurantService<Restaurant> restaurantService)
        {
            _timeLineService = timeLineService;
            _restaurantService = restaurantService;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            if (_sessionManager.User is not null) return View(_timeLineService.Get(_sessionManager.User.Id));
            else return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (_sessionManager.User is not null)
            {
                TimeLineAddForm start = new TimeLineAddForm() 
                    { NbrGuests = 1
                    , DinerDate = DateTime.Today
                    , SelectedResaurant = 0
                    , Restaurants = GetRestaurants()};
                return View(start);
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TimeLineAddForm form)
        {
            if (_sessionManager.User is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TimeLine tl = new TimeLine() 
                            { DinerDate = form.DinerDate
                            , NbrGuests = form.NbrGuests
                            , UserId = _sessionManager.User.Id
                            , RestaurantId = form.SelectedResaurant };

                    TimeLine tl2 = _timeLineService.Add(tl);
                        return RedirectToAction("index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    //ViewBag.Error = ex.Message;
                }
                return View();
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_sessionManager.User is not null)
            {
                TimeLine tl = _timeLineService.Get(_sessionManager.User.Id, id);

                TimeLineUpdForm start = new TimeLineUpdForm() 
                { NbrGuests = tl.NbrGuests
                , DinerDate = tl.DinerDate
                , SelectedResaurant = tl.RestaurantId
                , Restaurants = GetRestaurants() };
                return View(start);
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TimeLineUpdForm form)
        {
            if (_sessionManager.User is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TimeLine tl = new TimeLine() { Id= id
                            , DinerDate = form.DinerDate
                            , NbrGuests = form.NbrGuests
                            , UserId = _sessionManager.User.Id
                            , RestaurantId = form.SelectedResaurant};

                        bool updated = _timeLineService.Upd(id,tl);
                        if (!updated)
                        {
                            ViewBag.Message = "Error: Time Line NOT Updated (" + id.ToString() + ")";
                        }
                        return RedirectToAction("index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    //ViewBag.Error = ex.Message;
                }
                return View();
            }
            else return RedirectToAction("Login", "Auth");
        }

        public ActionResult Delete(int id)
        {
            TimeLine tl = _timeLineService.Get(_sessionManager.User.Id, id);
            if (tl is null) return RedirectToAction("Index");
            return View(tl);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (_sessionManager.User is not null)
            {
                bool deleted = _timeLineService.Del(_sessionManager.User.Id, id);
                if (!deleted)
                {
                    ViewBag.Message = "Error: Time Line NOT Deleted (" + id.ToString() + ")";
                }
                return RedirectToAction("Index", "TimeLine");
            }
            else return RedirectToAction("Login", "Auth");
        }


        private List<SelectListItem> GetRestaurants()
        {
            List<SelectListItem> restaurants = _restaurantService.Get().Select(n => new SelectListItem(n.Name, n.Id.ToString())).ToList();
            restaurants.Insert(0, new SelectListItem("--- select Restaurant ---" ,null));
            return restaurants;
        }
    }
}
