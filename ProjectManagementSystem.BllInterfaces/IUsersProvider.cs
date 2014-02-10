using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.BllInterfaces
{
    public interface IUsersProvider
    {
        bool CanUserLogIn(string login, string password);

        void CreateUser(string login, string password);

        int GetUserIdByLogin(string login);

        bool IsUserExist(string login);
    }
}
