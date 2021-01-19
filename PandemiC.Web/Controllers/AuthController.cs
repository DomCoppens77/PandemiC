using DCODatabase.ToolBox.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PandemiC.Web.Repo;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Infrastructure;
using PandemiC.Web.Models.Forms;
using System;

namespace PandemiC.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUserService<User> _iUserService;
        private readonly ISessionManager _sessionManager;
        private readonly ILogger _logger;

        public AuthController(IUserService<User> userService, ISessionManager sessionManager, ILogger<AuthController> logger)
        {
            _iUserService = userService;
            _sessionManager = sessionManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // check if email or natreg as login

                    User u = _iUserService.Login(form.Email, Base64.Base64Encode(form.Passwd));

                    //else 
                    //    User u = _iUserService.Login2("", Base64.Base64Encode(form.Passwd));

                    if (u is not null)
                    {
                        _sessionManager.User = new SessionUser()
                        { Id = u.Id, LastName = u.LastName, FirstName = u.FirstName, Email = u.Email, NatRegNbr = u.NatRegNbr, UserStatus = u.UserStatus, Passwd = "", Token = u.Token };
                        return RedirectToAction("Index", "TimeLine");
                    }

                    ModelState.AddModelError("", "Email ou mot de passe invalide...");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ModelState.AddModelError("", "Une erreur est survenue");
                //ViewBag.Error = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserAddForm form)
        {
            // auth ASP
            try
            {
                if (ModelState.IsValid)
                {
                    User u = new User() { Email = form.Email, FirstName = form.FirstName, LastName = form.LastName, NatRegNbr = form.NatRegNbr, Passwd = Base64.Base64Encode(form.Passwd) };
                    u = _iUserService.Add(u);
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                //ViewBag.Error = ex.Message;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            if (_sessionManager.User is not null)
            {
                User u = _iUserService.Get(_sessionManager.User.Id);
                UserUpdForm start = new UserUpdForm { Id = u.Id, Email = u.Email, UserStatus = u.UserStatus, NatRegNbr = u.NatRegNbr, FirstName = u.FirstName, LastName = u.LastName };
                return View(start);
            }
            else return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserUpdForm form)
        {
            if (_sessionManager.User is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        User u = new User { Id = id, Email = form.Email, FirstName = form.FirstName, LastName = form.LastName, NatRegNbr = form.NatRegNbr, UserStatus = form.UserStatus};
                        bool updated = _iUserService.Upd(u);
                        if (!updated)
                        {
                            ViewBag.Message = "Error: User NOT Updated (" + id.ToString() + ")";
                        }
                        return RedirectToAction("Index", "TimeLine");
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
        //[AuthRequired]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
