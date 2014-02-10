using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        
        public IUsersProvider userProvider { get; set; }
        
        private AuthorizationModel model;

        public AuthenticationController(IUsersProvider provider)
        {
            userProvider = provider;
        }

        /// <summary>
        /// Действие для перехода на страницу с формой для аутентификации.
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            model = new AuthorizationModel();
            return View(model);
        }

        
        /// <summary>
        /// Контролер для проведения аутентификации.
        /// В случае успеха происходит перенаправление на действие "Welcome" контроллера "SharedLoggedIn",
        /// пользователь переходит на главную страницу для авторизированных пользователей.
        /// В противном случае происходит перенаправление на страницу для аутентификации,
        /// где выводится соответствующее сообщение об ошибке.
        /// </summary>
        /// <param name="Login">логин пользователя</param>
        /// <param name="Password">пароль пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string Login, string Password)
        {
            model = new AuthorizationModel();
            var result = userProvider.CanUserLogIn(Login, Password);
            if (!result){
                model.isUserExist = false;
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(Login, false);
            return RedirectToAction("Welcome", "SharedLoggedIn");
        }

        
        /// <summary>
        /// Выход из системы.
        /// Удаление аутентификационных cookies.
        /// В результате пользователь перенаправляется на стартовую страницу.
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
