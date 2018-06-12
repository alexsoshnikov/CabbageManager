using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public class UI_Logic
    {
        DbRepository _repo = Factory.Instance.GetRepository();
        public static string errorRegistrationText { get; set; }


        public User CreateNewUser(string name, string email, string password)
        {
            if (!Emailcheck(email))
            {
                errorRegistrationText += "email is not valid\n";
            }
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                errorRegistrationText += "some fields are empty\n";
            }
            if (!String.IsNullOrEmpty(errorRegistrationText))
            {
                return null;
            }
            var user = new User { Name = name, Email = email, Password = DbRepository.GetHash(password), UserBudget = new UserBudget { UserEmail = email } };
            return user;
        }
        
        public static bool Emailcheck(string email)
        {
            return Regex.IsMatch(email,
             @"^[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        }

    }
}
