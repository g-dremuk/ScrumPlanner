using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;
using System.Text;

namespace ProjectManagementSystem.Controllers
{
    public class ManagerController : Controller
    {

        ProjectsListModel model;
        ShowCurrentIterationForProject iterModel;

        public IItemsLists itemsList { get; set; }
        public IManager manager{ get; set; }
        public IStorage storage { get; set; }

        public ManagerController(IItemsLists ItemsList, IManager Manager, IStorage Storage)
        {
            itemsList = ItemsList;
            manager = Manager;
            storage = Storage;
        }

        
        /// <summary>
        /// Действие для перехода на страницу для добавления новой задачи в существующий проект.
        /// Формируется список всех доступных проектов, сведения берутся из базы данных.
        /// </summary>
        /// <returns>Возвращает список пар value - text, где value - идентификатор проекта, а text - имя проекта</returns>
        [Authorize(Roles = @"Manager")]
        public ActionResult AddNewTaskToProject()
        {
            //List<Project> list = IItemsLists.GetAllProjects();
            model = new ProjectsListModel();
            foreach (ProjectInfo prjInf in itemsList.GetAllProjects())
            {
                model.AllProjects.Add(new SelectListItem() { Value = prjInf.Id.ToString(), Text = prjInf.Name });
            }
            return View(model);
        }

        
        /// <summary>
        /// Действие для сохранения новых задач в базе данных для выьранного проекта 
        /// </summary>
        /// <param name="idProject">идентиыикатор проекта, к которому добавляются задачи</param>
        /// <param name="name">имя новой задачи</param>
        /// <param name="description">описание новой задачи</param>
        /// <param name="profit">полезность новой задачи</param>
        /// <param name="time">продолжительность новой задачи</param>
        /// <returns>Сообщение об успешном завершении операции.</returns>
        [HttpPost]
        [Authorize(Roles = @"Manager")]
        public JsonResult AddNewTaskToProject(int idProject, string name, string description, int profit, int time)
        {
            manager.AddNewTaskToProject(idProject, name, description, profit, time);
            return Json(new { resStatus = "Ok" });
        }

        
        /// <summary>
        /// Действие для перехода на страницу для добавления нового проекта.
        /// </summary>
        /// <returns>Сообщение об успешном завершении операции.</returns>
        [HttpGet]
        [Authorize(Roles = @"Manager")]
        public ActionResult CreateNewProject()
        {

            return View();
        }

        
        /// <summary>
        /// Действие для сохранения нового проекта.
        /// </summary>
        /// <param name="createProjectName">имя нового проекта</param>
        /// <param name="createProjectDescription">описание нового проекта</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = @"Manager")]
        public ActionResult CreateNewProject(string createProjectName, string createProjectDescription)
        {
            manager.CreateNewProject(createProjectName, createProjectDescription);
            return RedirectToAction("AddNewTaskToProject");
        }

        
        /// <summary>
        /// Действие для перехода на страницу для генерации новой итерации.
        /// Формируется список всех доступных проектов, для которых возможна генерирования итераций.
        /// Сведения о проектах берутся из базы данных.
        /// </summary>
        /// <returns>Возвращает список пар value - text, где value - идентификатор проекта, а text - имя проекта</returns>
        [Authorize(Roles = @"Manager")]
        public ActionResult GenerateIteration()
        {
            //List<Project> list = IItemsLists.GetAllProjects();
            model = new ProjectsListModel();
            foreach (ProjectInfo prjInf in itemsList.GetAllProjects())
            {
                model.AllProjects.Add(new SelectListItem() { Value = prjInf.Id.ToString(), Text = prjInf.Name });
            }
            return View(model);
        }

        
        /// <summary>
        /// Генерируется итерация для проекта с заданным идентификатором и
        /// автоматически сохраняется.
        /// Пользователю выводится строка специального вида, описывающая сгенерированную итерацию.
        /// </summary>
        /// <param name="idProject">идентификатор поекта, для которого генерируется итерация</param>
        /// <returns>строка, описывающая сгенерированную итерацию</returns>
        [HttpPost]
        [Authorize(Roles = @"Manager")]
        public JsonResult GenerateIteration(int idProject)
        {
            var result = new StringBuilder();
            foreach (TaskInfo task in manager.GenerateIteration(idProject))
            {
                result.Append("name=" + task.Name
                    + ", description=" + task.Description
                    + ", profit=" + task.Profit
                    + ", time=" + task.Duration
                    +"<br>");
            }
            return Json(new
            {
                resStatus = "Ok",
                Tasks = result.ToString()
            });
        }


        /// <summary>
        /// Действие для перехода на страницу для просмотра задач определенной итерации, определенного поекта.
        /// Формируется список всех доступных проектов, для которых возможен просмотр задач итераций.
        /// Сведения о проектах берутся из базы данных.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = @"Manager")]
        public ActionResult ShowCurrentIterationForProject()
        {
            //List<Project> list = IItemsLists.GetAllProjects();
            iterModel = new ShowCurrentIterationForProject();
            foreach (ProjectInfo prjInf in itemsList.GetAllProjects())
            {
                iterModel.AllProjects.Add(new SelectListItem() { Value = prjInf.Id.ToString(), Text = prjInf.Name });
            }
            return View(iterModel);
        }

       
        /// <summary>
        /// Действие для загрузки итераций определенного поекта.
        /// Формируется список всех доступных итераций, для которых возможен просмотр задач.
        /// Сведения о итерациях берутся из базы данных.
        /// </summary>
        /// <param name="projectId">идентификатор проекта, для которого загружаются итерации</param>
        /// <returns>список итераций для заданного проекта</returns>
        [HttpPost]
        [Authorize(Roles = @"Manager")]
        public JsonResult ShowCurrentIterationForProject(int projectId)
        {
            var numberOfIterations = storage.GetIterationCounterForProject(projectId);
            var result = new StringBuilder();
            for (int i = 1; i <= numberOfIterations; i++ )
            {
                result.Append("<option value="+i+">Iteration "+i+"</option>");
            }
            return Json(new
            {
                resStatus = "Ok",
                Iterations = result.ToString(),
                numberOfIterations = numberOfIterations
            });
        }


        /// <summary>
        /// Действие для загрузки задач определенной итерации определенного поекта.
        /// Формируется список всех задач из определенной итерации определенного поекта.
        /// Сведения о задачах берутся из базы данных.
        /// </summary>
        /// <param name="projectId">идентификатор проекта, для которого загружаются задачи</param>
        /// <param name="iterNumber">идентификатор итерации, для которого загружаются задачи</param>
        /// <returns>список задач определенной итерации определенного поекта</returns>
        [HttpPost]
        [Authorize(Roles = @"Manager")]
        public JsonResult ShowCurrentTasksForIteration(int projectId, int iterNumber)
        {
            iterModel = new ShowCurrentIterationForProject();
            List<TaskInfo> iter = storage.GetTasksInIteration(projectId, iterNumber);
            var result = new StringBuilder();
            result.Append("<label><h4>The iteration number " + iterNumber + " for Project number " + projectId + "</h4></label>");
            int i = 1;
            foreach (TaskInfo tskInf in iter)
            {
                result.Append("<label>   " + i + "). The task name is " + tskInf.Name + ". It's description is " + tskInf.Description + "</label>");
                i++;
            }
            result.Append("</select>");
            return Json(new
            {
                resStatus = "Ok",
                Iterations = result.ToString(),
                numberOfTasks = iter.Count
            });
        }
    }
}
