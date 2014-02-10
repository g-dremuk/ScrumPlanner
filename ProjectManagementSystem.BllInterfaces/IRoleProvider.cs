using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagementSystem.BllInterfaces
{
    public interface IRoleProvider
    {
        void AddUsersToRoles(string[] usernames, string[] roleNames);

        void AddUserToRole(string username, string roleName);

        string[] GetAllRoles();

        string[] GetRolesForUser(string username);

        bool IsUserInRole(string username, string roleName);

        bool RoleExists(string roleName);
    }
}
