using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.SecurityProviders
{
    public static class DatabaseConnectHelper
    {
        public static string GetUserPassword(string login)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT Password FROM Users WHERE Login = @login", connection))
                {
                    command.Parameters.Add(new SqlParameter("@login", login));
                    var result = (string)command.ExecuteScalar();

                    return result;
                }
            }
        }

        public static string GetUserRole(string login)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT Roles.Name FROM Users INNER JOIN Roles ON Users.RoleId = Roles.Id WHERE Users.Login = @login", connection))
                {
                    command.Parameters.Add(new SqlParameter("@login", login));
                    var result = (string)command.ExecuteScalar();

                    return result;
                }
            }
        }
    }
}