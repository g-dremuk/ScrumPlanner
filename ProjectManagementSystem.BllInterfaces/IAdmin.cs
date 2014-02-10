using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BllInterfaces
{
    public interface IAdmin
    {
        void AddNewUser(string Login, string Password, string SelectedRole);

        void UpdateTask(int idTask, string name, string description, int profit, int duration, int? idUser);
        void UpdateUser(int idUser, string newLogin, string newPassword, string newRole);

    }
}
