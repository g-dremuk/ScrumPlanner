using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.BllInterfaces
{
    public interface IProgrammer
    {
        void saveSelectedTask(int idUser, int idTask);

        void CheckSelectedTaskAsSolved(int taskId);
    }
}
