using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    [Authorize]
    public class InternalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}