using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public class DbRepository
    {
        public List<User> users { get; set; }
        public List<HistoryItem> historyItems { get; set; }
        public List<UserBudget> userBudgets { get; set; }
        public List<Category> categories { get; set; }
        
        private const string usersFileName = "..//..//..//Cabbage_Manager_Classes/Data/users.json";
        private const string historyItemsFileName = "..//..//..//Cabbage_Manager_Classes/Data/historyitems.json";
        private const string userbudgetsFileName = "..//..//..//Cabbage_Manager_Classes/Data/userbudgets.json";
        private const string categoriesFileName = "..//..//..//Cabbage_Manager_Classes/Data/categories.json";


        public User _authorizedUser;

        public Context Context { get; set; }

        public DbRepository()
        {
            Context = new Context();
            users = Context.Users.ToList();
            historyItems = Context.TotalHistory.ToList();
            userBudgets = Context.UserBudgets.ToList();
            var repo = new RepositoryJson();
            categories = repo.categories;
        }

        public bool Authorize(string login, string password)
        {
            users = Context.Users.ToList();
            var Hash = GetHash(password);
            var user = users.FirstOrDefault(u => u.Email == login && u.Password == Hash);
            if (user != null)
            {
                _authorizedUser = user;
                if (userBudgets.FirstOrDefault(b => b.UserEmail == user.Email) != null)
                {
                    _authorizedUser.UserBudget = userBudgets.FirstOrDefault(b => b.UserEmail == user.Email);
                }
                Save();
                return true;
            }
            return false;
        }

        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        public void RegisterUser(User user)
        {
            //_authorizedUser = user;
            if (user != null)
            {
                UI_Logic.errorRegistrationText = string.Empty;
                Context.Users.Add(user);
                Save();
            }
            else
            {
                throw new SystemException(UI_Logic.errorRegistrationText);
            }
        }
        public void Save()
        {
            Context.SaveChanges();
        }
        
        //CRUD
    }
}
