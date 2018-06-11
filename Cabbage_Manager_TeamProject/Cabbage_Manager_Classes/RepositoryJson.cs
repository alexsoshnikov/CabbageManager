using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public class RepositoryJson
    {
        public List<Category> categories { get; set; }
        public List<User> users { get; set; }
        public List<HistoryItem> historyItems { get; set; }
        public List<UserBudget> userBudgets { get; set; }

        //поенять ссылки на те,чтов  папке data
        private const string categoriesFileName = "..//..//..//Cabbage_Manager_Classes/Data/categories.json";
        private const string usersFileName = "..//..//..//Cabbage_Manager_Classes/Data/users.json";
        private const string historyItemsFileName = "..//..//..//Cabbage_Manager_Classes/Data/historyitems.json";
        private const string userbudgetsFileName = "..//..//..//Cabbage_Manager_Classes/Data/userbudgets.json";

        public RepositoryJson()
        {
            //Save();
            Restore();
        }
        private List<T> RestoreList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }
        
        private void SaveList<T>(string fileName, List<T> list)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;

                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, list);
                }
            }
        }
        public void Save()
        {
            /*
            categories = new List<Category>();
            categories.Add(new Category { Id = 1, Name = "Food", ColourCode = "#FF7F50" });
            categories.Add(new Category { Id = 2, Name = "Eating out", ColourCode = "#DC143C" });
            categories.Add(new Category { Id = 3, Name = "Entertainment", ColourCode = "#DB7093" });
            categories.Add(new Category { Id = 4, Name = "Transport", ColourCode = "##8FBC8F" });
            categories.Add(new Category { Id = 5, Name = "Health and beauty", ColourCode = "#6B8E23" });
            categories.Add(new Category { Id = 6, Name = "Clothes", ColourCode = "#A52A2A" });
            categories.Add(new Category { Id = 7, Name = "Purchases", ColourCode = "#D2B48C" });
            SaveList(categoriesFileName, categories);
            

            userBudgets = new List<UserBudget>();
            userBudgets.Add(new UserBudget { Id = 1, CashSum = 100, CreditCardSum = 100, TotalBalance = 200 });
            userBudgets.Add(new UserBudget { Id = 2, CashSum = 1000, CreditCardSum = 1000, TotalBalance = 2000 });
            SaveList( userbudgetsFileName, userBudgets);

            historyItems = new List<HistoryItem>();
            historyItems.Add(new HistoryItem { Id = 1, Amount = 10, CategoryId = 1, Type = "I", UserEmail= "alex@mail.ru" });
            historyItems.Add(new HistoryItem { Id = 2, Amount = 100, CategoryId = 1, Type = "E", UserEmail= "altyn@mail.ru" });
            SaveList(historyItemsFileName, historyItems);

            users = new List<User>();
            users.Add(new User { Id = 1, Name = "Alex", Password = "123", Email="alex@mail.ru" });
            users.Add(new User { Id = 2, Name = "Altyn", Password = "123", Email = "altyn@mail.ru" });
            SaveList(usersFileName, users);
            */
        }


        private void Restore()
        {
            categories = RestoreList<Category>(categoriesFileName);
            users = RestoreList<User>(usersFileName);
            historyItems = RestoreList<HistoryItem>(historyItemsFileName);
            userBudgets= RestoreList<UserBudget>(userbudgetsFileName);
        }

    }
}
