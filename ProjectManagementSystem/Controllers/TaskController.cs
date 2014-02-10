using System.Web.Mvc;
using ProjectManagementSystem.BllInterfaces;

namespace ProjectManagementSystem.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        public IManager Manager { get; set; }

        public TaskController(IManager manager)
        {
            Manager = manager;
        }

        public ActionResult View()
        {
            var tasks = Manager.GetAllTasks();
            return View(tasks);
        }
    }
}