using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.BllInterfaces;

namespace ProjectManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private const int MinRequiredPasswordLenth = 6;

        public IItemsLists itemsList { get; set; }
        public IAdmin admin { get; set; }
        public IUsersProvider userProvider { get; set; }

        private AddNewUserModel model;

        public AdminController(IItemsLists ItemsList, IAdmin Admin, IUsersProvider UserProvider)
        {
            itemsList = ItemsList;
            admin = Admin;
            userProvider = UserProvider;
        }

        /// <summary>
        /// Действие для перехода на страницу добавления пользователя.
        /// </summary>
        
        [Authorize(Roles = @"Admin")]
        public ActionResult AddNewUser()
        {
            model = new AddNewUserModel();
            return View(model);
        }

        ///<summary>
        /// Производится непосредственное добавление нового пользователя.
        /// Регестрация производится через компоненты BLL: IUserProvider.
        /// </summary>
        /// <param name="Login">логин нового пользователя</param>
        /// <param name="Password">пароль нового пользователя</param>
        /// <param name="SelectedRole">права доступа нового пользователя</param>
        [HttpPost]
        [Authorize(Roles = @"Admin")]
        public ActionResult AddNewUser(string Login, string Password, string SelectedRole)
        {
            model = new AddNewUserModel();
            if (Password.Length < MinRequiredPasswordLenth)
                model.isInvalidPasswordLenth = true;
            if (userProvider.IsUserExist(Login))
                model.isUserExist = true;
            if ((!model.isInvalidPasswordLenth) && (!model.isUserExist))
            {
                admin.AddNewUser(Login, Password, SelectedRole);
                model.isSucced = true;
            }
            return View(model);
        }

        /// <summary>
        /// Действие для перехода на страницу изменения пользователя.
        /// Формируется список всех доступных пользователей, сведения берутся из базы данных.
        /// </summary>
        /// <returns>Возвращает список пар value - text, где value - идентификатор пользователя, а text - логин пользователя</returns>
        [HttpGet]
        [Authorize(Roles = @"Admin")]
        public ActionResult EditUser()
        {
            UsersListModel model = new UsersListModel();
            foreach(UserInfo usrInf in itemsList.GetAllUsers())
            {
                model.AllUsers.Add(new SelectListItem() { Value = usrInf.Id.ToString(), Text = usrInf.Login });
            }
            return View(model);
        }

        /// <summary>
        /// Действие для сохранения изменений пользователей в базе данных.
        /// Изменять можно пароль и роль.
        /// </summary>
        /// <param name="userName">логин пользователя</param>
        /// <param name="newPassword">новый пароль для пользователя</param>
        /// <param name="newRole">новая роль для пользователя</param>
        /// <param name="id">идентификатор пользователя, для которого меняются поля.</param>
        /// <returns>Сообщение об успешном завершении операции.</returns>
        [HttpPost]
        [Authorize(Roles = @"Admin")]
        public JsonResult EditUser(string userName, string newPassword, string newRole, int id)
        {
            //save changes here
            admin.UpdateUser(id, userName, newPassword, newRole);
            //-----------------
            return Json(new
            {
                resStatus = "Ok"
            });
        }

        /// <summary>
        /// Действие для перехода на страницу изменения задачи.
        /// Формируется список всех доступных задач, сведения берутся из базы данных.
        /// </summary>
        /// <returns>Возвращает список пар value - text, где value - идентификатор задачи, а text - название задачи</returns>
        [HttpGet]
        [Authorize(Roles = @"Admin")]
        public ActionResult EditTask()
        {
            TasksListModel model = new TasksListModel();
            foreach (TaskInfo tskInf in itemsList.GetAllTasks())
            {
                model.AllTasks.Add(new SelectListItem() { Value = tskInf.Id.ToString(), Text = tskInf.Name });
            }
            return View(model);
        }

        /* контроллер для сохранения изменений задач в базе данных 
         * менять можно описание(description), длительность и прибыль.
         * Можно считать, что путая строка - параметр, который не надо менять
         * Параметры:
         *      id - id задачи, для которого меняются поля.
         *      description, profit, task - новые значения полей
         * Возвращать ничего не нужно, да и оно ни на что не влияет.
         */
        /// <summary>
        /// Действие для сохранения изменений задач в базе данных.
        /// Изменять можно описание, полезность и длительность.
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <param name="name">название задачи</param>
        /// <param name="description">новое описание задачи</param>
        /// <param name="profit">новая полезность задачи</param>
        /// <param name="time">новая длительность задачи</param>
        /// <returns>Сообщение об успешном завершении операции.</returns>
        [HttpPost]
        [Authorize(Roles = @"Admin")]
        public JsonResult EditTask(int id, string name, string description, int profit, int time)
        {
            admin.UpdateTask(id, name, description, profit, time, null);
            return Json(new
            {
                resStatus = "Ok"
            });
        }
    }
}
