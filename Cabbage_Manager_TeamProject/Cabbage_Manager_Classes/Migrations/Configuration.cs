namespace Cabbage_Manager_Classes.Migrations
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<Cabbage_Manager_Classes.Context>
    {
        public List<User> users { get; set; }
        public List<HistoryItem> historyItems { get; set; }
        public List<UserBudget> userBudgets { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cabbage_Manager_Classes.Context context)
        {
            // This method will be called after migrating to the latest version. 

            const string usersFileName = "Cabbage_Manager_Classes.Data.users.json";
            const string historyItemsFileName = "Cabbage_Manager_Classes.Data.historyitems.json";
            const string userbudgetsFileName = "Cabbage_Manager_Classes.Data.userbudgets.json";

            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var sr = new StreamReader(assembly.GetManifestResourceStream(usersFileName)))
                {
                    using (var jsonReader = new JsonTextReader(sr))
                    {
                        var serializer = new JsonSerializer();
                        users = serializer.Deserialize<List<User>>(jsonReader);
                    }
                }
                using (var sr = new StreamReader(assembly.GetManifestResourceStream(historyItemsFileName)))
                {
                    using (var jsonReader = new JsonTextReader(sr))
                    {
                        var serializer = new JsonSerializer();
                        historyItems = serializer.Deserialize<List<HistoryItem>>(jsonReader);
                    }
                }
                using (var sr = new StreamReader(assembly.GetManifestResourceStream(userbudgetsFileName)))
                {
                    using (var jsonReader = new JsonTextReader(sr))
                    {
                        var serializer = new JsonSerializer();
                        userBudgets = serializer.Deserialize<List<UserBudget>>(jsonReader);
                    }
                }
            }
            catch
            {
                // If something goes wrong, start off with empty collections 

                users = new List<User>();
                historyItems = new List<HistoryItem>();
                userBudgets = new List<UserBudget>();

            }

            foreach (var user in users)
            {
                user.UserBudget = userBudgets.FirstOrDefault(b => b.UserEmail == user.Email);
                context.Users.AddOrUpdate(u => u.Email, user);
            }
            foreach (var historyitem in historyItems)
            {
                historyitem.UserBudget = userBudgets.FirstOrDefault(b => b.UserEmail == historyitem.UserEmail);
                context.TotalHistory.AddOrUpdate(hi => hi.Id, historyitem);
            }

            foreach (var budget in userBudgets)
            {
                context.UserBudgets.AddOrUpdate(b => b.Id, budget);
            }
        }
    }
}