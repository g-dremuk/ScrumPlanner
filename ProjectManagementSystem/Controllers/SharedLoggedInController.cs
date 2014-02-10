using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class SharedLoggedInController : Controller
    {
        //
        // GET: /SharedLoggedIn/

        
        /// <summary>
        /// Действие для перехода на главную страницу для авторизированных пользователей.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }

    }
}
