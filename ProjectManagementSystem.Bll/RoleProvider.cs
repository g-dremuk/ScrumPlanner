using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.BllInterfaces;

namespace ProjectManagementSystem.Bll
{
    public class RoleProvider : IRoleProvider
    {
        public IStorage Storage { get; set; }

        public RoleProvider(IStorage storage)
        {
            if (storage == null) throw new ArgumentNullException("storage");

            Storage = storage;
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            for (int i = 0; i < usernames.Length; i++)
            {
                for (int j = 0; j < roleNames.Length; j++)

                    this.AddUserToRole(usernames[i], roleNames[j]);
            }
        }

        public string[] GetAllRoles()
        {
            return new string[] { "Admin", "Manager", "Coder" };
        }

        public string[] GetRolesForUser(string username)
        {
            return new string[] { Storage.GetUserRole(username) };
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return roleName == Storage.GetUserRole(username);
        }

        public bool RoleExists(string roleName)
        {
            return (roleName == "Admin" || roleName == "Manager" || roleName == "Coder");
        }


        public void AddUserToRole(string username, string roleName)
        {
            Storage.AddUserToRole(username, roleName);
        }
    }
}
