using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.Dal.DatabaseModels;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Dal.Translators
{
    internal class UserTranslator
    {
        public static UserInfo ToUserInfo(User user)
        {
            var result = new UserInfo(user.Id, user.Login, user.Password);
            return result;
        }

        public static List<UserInfo> ToListUserInfo(User[] user)
        {
            var result = user.Select(ToUserInfo).ToList();
            return result;
        }
    }
}
