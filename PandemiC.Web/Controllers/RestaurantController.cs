using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Infrastructure;
using PandemiC.Web.Models.Forms.Restaurant;
using PandemiC.Web.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService<Restaurant> _restaurantService;
        private readonly ICountryService<Country> _countryService;
        private readonly ISessionManager _sessionManager;

        public RestaurantController(IRestaurantService<Restaurant> restaurantService, ISessionManager sessionManager, ICountryService<Country> countryService)
        {
            _restaurantService = restaurantService;
            _countryService = countryService;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            if (_sessionManager.User is not null) return View(_restaurantService.Get());
            else return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (_sessionManager.User is not null)
            {
                RestaurantAddForm start = new RestaurantAddForm()
                {
                     Countries = GetCountries()
                };
                return View(start);
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantAddForm form)
        {
            if (_sessionManager.User is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Restaurant resto = new Restaurant()
                        {
                             Name = form.Name,
                             VAT  =form.VAT,
                             Address1 = form.Address1, 
                             Address2 = form.Address2,
                             City = form.City, 
                             Zip = form.Zip,
                             Country = form.SelectedCountry, 
                             Email = form.Email, 
                             Closed = form.Closed
                        };

                        Restaurant resto2 = _restaurantService.Add(resto);
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
                Restaurant resto = _restaurantService.Get(id);

                RestaurantUpdForm start = new RestaurantUpdForm()
                {
                    Id = id,
                    Name = resto.Name,
                    VAT = resto.VAT,
                    Address1 = resto.Address1,
                    Address2 = resto.Address2,
                    City = resto.City,
                    Zip = resto.Zip,
                    SelectedCountry = resto.Country,
                    Countries = GetCountries(),
                    Email = resto.Email,
                    Closed = resto.Closed
                };
                return View(start);
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantUpdForm form)
        {
            if (_sessionManager.User is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Restaurant resto = new Restaurant()
                        {
                            Id = id,
                            Name = form.Name,
                            VAT = form.VAT,
                            Address1 = form.Address1,
                            Address2 = form.Address2,
                            City = form.City,
                            Zip = form.Zip,
                            Country = form.SelectedCountry,
                            Email = form.Email,
                            Closed = form.Closed

                        };

                        bool updated = _restaurantService.Upd(resto);
                        if (!updated)
                        {
                            ViewBag.Message = "Error: Restaurant NOT Updated (" + id.ToString() + ")";
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
            Restaurant resto = _restaurantService.Get(id);
            if (resto is null) return RedirectToAction("Index");
            return View(resto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (_sessionManager.User is not null)
            {
                bool deleted = _restaurantService.Del(id);
                if (!deleted)
                {
                    ViewBag.Message = "Error: Restaurant NOT Deleted (" + id.ToString() + ")";
                }
                return RedirectToAction("Index", "Restaurant");
            }
            else return RedirectToAction("Login", "Auth");
        }

        private List<SelectListItem> GetCountries()
        {
            List<SelectListItem> countries = _countryService.Get().Select(n => new SelectListItem(n.Ctry, n.ISO)).ToList();
            countries.Insert(0, new SelectListItem("--- select Country ---", null));
            return countries;
        }
    }
}
