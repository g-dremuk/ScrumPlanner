using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;

namespace ProjectManagementSystem.Controllers
{
    public class ProgrammerController : Controller
    {
        private TasksListModel taskListModel;
        private MarkTaskAsSolvedModel markTaskModel;
        
        public IItemsLists itemsList { get; set; }
        public IProgrammer programmer { get; set; }
        public IUsersProvider userProvider { get; set; }
        public IStorage storage { get; set; }

        public ProgrammerController(IItemsLists ItemsList, IProgrammer Programmer, IUsersProvider user, IStorage Storage)
        {
            itemsList = ItemsList;
            programmer = Programmer;
            userProvider = user;
            storage = Storage;
        }

        
        /// <summary>
        /// Действие для перехода на страницу для выбора задач программистом.
        /// Формируется список всех доступных задач, сведения берутся из базы данных.
        /// </summary>
        /// <returns>Возвращает список пар value - text, где value - идентификатор задачи, а text - название задачи</returns>
        [HttpGet]
        [Authorize(Roles = @"Programmer")]
        public ActionResult SelectTask()
        {
            // List<Task> list = IItemsLists.GetAllTasks();
            taskListModel = new TasksListModel();
            foreach (TaskInfo tskInf in itemsList.GetTasksForWork())
            {
                taskListModel.AllTasks.Add(new SelectListItem() { Value = tskInf.Id.ToString(), Text = tskInf.Name });
            }
            return View(taskListModel);
        }

        
        /// <summary>
        /// Действие для закрепления задачи за выбирающим программистом.
        /// Идентификация программиста осуществляется посредством аутентификационых куков.
        /// </summary>
        /// <param name="id">идентификатор выбранной задачи</param>
        /// <returns>Сообщение об успешном завершении операции.</returns>
        [HttpPost]
        [Authorize(Roles = @"Programmer")]
        public JsonResult SelectTask(int id)
        {
            programmer.saveSelectedTask(userProvider.GetUserIdByLogin(HttpContext.User.Identity.Name), id);
            return Json(new
            {
                resStatus = "Ok"
            });
        }

        /// <summary>
        /// Действие для пометки задачи как решенной программистом.
        /// Формируется список задач, выбранных для решения, но не решенных.
        /// </summary>
        /// <returns>Возвращает список пар value - text, где value - идентификатор задачи, а text - название задачи</returns>
        [HttpGet]
        [Authorize(Roles = @"Programmer")]
        public ActionResult MarkTaskAsSolved()
        {
            markTaskModel = new MarkTaskAsSolvedModel();
            foreach (TaskInfo tskInf in storage.GetWorkTasks(userProvider.GetUserIdByLogin(HttpContext.User.Identity.Name)))
            {
                markTaskModel.AllWorkedTask.Add(new SelectListItem() { Value = tskInf.Id.ToString(), Text = tskInf.Name });
            }
            return View(markTaskModel);
        }


        /// <summary>
        /// Действие для пометки программистом задачи как решенной.
        /// Идентификация программиста осуществляется посредством аутентификационых куков.
        /// </summary>
        /// <param name="AllWorkedTask">номер задачи, помечаемой как решенная.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = @"Programmer")]
        public ActionResult MarkTaskAsSolved(int AllWorkedTask)
        {
            markTaskModel = new MarkTaskAsSolvedModel();
            try
            {
                programmer.CheckSelectedTaskAsSolved(AllWorkedTask);
                markTaskModel.isSucced = true;

                foreach (TaskInfo tskInf in storage.GetWorkTasks(userProvider.GetUserIdByLogin(HttpContext.User.Identity.Name)))
                {
                    markTaskModel.AllWorkedTask.Add(new SelectListItem() { Value = tskInf.Id.ToString(), Text = tskInf.Name });
                }
                return View(markTaskModel);
            }
            catch (Exception e)
            {
                markTaskModel.isSucced = false;
                markTaskModel.errorMessage = "Some server errors. Please try again later.";
                return View(markTaskModel);
            }
        }
    }
}
