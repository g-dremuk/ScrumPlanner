using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.Dal.DatabaseModels;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Dal.Translators
{
    internal class ProjectTranslator
    {
        public static ProjectInfo ToProjectInfo(Project project)
        {
            var result = new ProjectInfo(project.Id, project.Name, project.Description);
            return result;
        }

        public static List<ProjectInfo> ToListProjectInfo(Project[] project)
        {
            var result = project.Select(ToProjectInfo).ToList();
            return result;
        }
    }
}
