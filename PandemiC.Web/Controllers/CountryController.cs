using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Infrastructure;
using PandemiC.Web.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService<Country> _countryService;
        private readonly ISessionManager _sessionManager;

        public CountryController(ICountryService<Country> countryService, ISessionManager sessionManager )
        {
            _countryService = countryService;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            if (_sessionManager.User is not null) return View(_countryService.Get());
            else return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (_sessionManager.User is not null)
            {
                return View();
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country form)
        {
            if (_sessionManager.User is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _countryService.Add(form);
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
        public IActionResult Edit(string ISO)
        {
            if (_sessionManager.User is not null)
            {
                return View(_countryService.Get(ISO));
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string ISO, Country form)
        {
            if (_sessionManager.User is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        bool updated = _countryService.Upd(form);
                        if (!updated)
                        {
                            ViewBag.Message = "Error: Restaurant NOT Updated (" + ISO + ")";
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
        public ActionResult Delete(string ISO)
        {
            if (_sessionManager.User is not null)
            {
                return View(_countryService.Get(ISO));
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string ISO, IFormCollection collection)
        {
            if (_sessionManager.User is not null)
            {
                bool deleted = _countryService.Del(ISO);
                if (!deleted)
                {
                    ViewBag.Message = "Error: Restaurant NOT Deleted (" + ISO + ")";
                }
                return RedirectToAction("Index", "Restaurant");
            }
            else return RedirectToAction("Login", "Auth");
        }
    }
}
