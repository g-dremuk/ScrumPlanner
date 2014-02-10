using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Bll
{
    public class UsersProvider : IUsersProvider
    {
        public IStorage Storage { get; set; }

        public UsersProvider(IStorage storage)
        {
            if (storage == null) throw new ArgumentNullException("storage");

            Storage = storage;
        }

        public bool CanUserLogIn(string login, string password)
        {
            var realPassword = Storage.GetUserPasswordByLogin(login);

            return realPassword == password;
        }

        public void CreateUser(string login, string password)
        {
            if (Storage.IsUserExist(login))
            {
                throw new ApplicationException("User is exist!");
            }

            if (password.Length < 6)
            {
                throw new ApplicationException("Password length must be 6 or longer!");
            }

            Storage.CreateUser(login, password);

            if (!Storage.IsUserExist(login) || !this.ValidateUser(login, password))
            {
                throw new ApplicationException("Something wrong. User isn't created. Creating error!");
            }
        }

        public bool ValidateUser(string username, string password)
        {
            var currentPassword = Storage.GetUserPassword(username);

            return currentPassword == password;
        }

        public int GetUserIdByLogin(string login)
        {
            return Storage.GetUserIdByLogin(login);
        }

        public bool IsUserExist(string login)
        {
            return Storage.IsUserExist(login);
        }
    }
}
