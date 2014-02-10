using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagementSystem.Models
{
    public class UserInfo
    {
        public UserInfo(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public UserInfo(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }

        public UserInfo(int id, string login, string newPassword, string newRole)
        {
            // TODO: Complete member initialization
            this.Id = id;
            this.Login = login;
            this.Password = newPassword;
            this.Role = newRole;
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
