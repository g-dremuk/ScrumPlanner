using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Bll
{
    public class Admin : IAdmin 
    {
        public IStorage Storage { get; set; }
        public IUsersProvider UserManager { get; set; }
        public IRoleProvider RoleManager { get; set; }

        public Admin(IStorage storage, IUsersProvider user, IRoleProvider role)
        {
            if (storage == null) throw new ArgumentNullException("storage");
            if (user == null) throw new ArgumentNullException("user provider");
            if (role == null) throw new ArgumentNullException("role provider");

            UserManager = user;
            RoleManager = role;
            Storage = storage;
        }

        public void AddNewUser(string Login, string Password, string SelectedRole)
        {
            UserManager.CreateUser(Login, Password);
            RoleManager.AddUserToRole(Login, SelectedRole);
        }

        public void UpdateTask(int idTask, string name, string description, int profit, int duration, int? idUser)
        {
            Storage.UpdateTask(new TaskInfo(idTask, name, description, profit, duration));
        }

        public void UpdateUser(int idUser, string newLogin, string newPassword, string newRole)
        {
            Storage.UpdateUser(new UserInfo(idUser, newLogin, newPassword, newRole));
        }
    }
}
