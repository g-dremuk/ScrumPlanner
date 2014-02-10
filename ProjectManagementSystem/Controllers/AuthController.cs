using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.Helper;

namespace ProjectManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        public IUsersProvider UsersProvider { get; set; }

        public AuthController(IUsersProvider usersProvider)
        {
            UsersProvider = usersProvider;
        }

        public ActionResult Index()
        {
            ViewBag.Page = ApplicationPage.Login;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            var canLogIn = UsersProvider.CanUserLogIn(login, password);
            if (!canLogIn)
                return View("Index");

            FormsAuthentication.SetAuthCookie(login, false);

            return RedirectToAction("Index", "Internal");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
