﻿using System;
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
                errorRegistrationText += "- Email is not valid\n";
            }
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                errorRegistrationText += "- Some fields are empty\n";
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
        public decimal Calculate(string formula)
        {
            decimal c = 0;
            if (formula.Contains('+') || formula.Contains('-'))
            {
                string[] sum = formula.Split('+');
                for (int j = 0; j < sum.Length; j++)
                {
                    if (sum[j].Contains('-'))
                    {
                        string[] devis = sum[j].Split('-');
                        decimal f = Convert.ToDecimal(devis[0]);
                        for (int i = 1; i < devis.Length; i++)
                        {
                            f -= Convert.ToDecimal(devis[i]);
                        }
                        sum[j] = Convert.ToString(f);
                    }
                }
                for (int i = 0; i < sum.Length; i++)
                {
                    c += Convert.ToDecimal(sum[i]);
                }
            }
            else
                c= Convert.ToDecimal(formula);
            return c;
        }
        public bool CheckAmountFormValid (string amountText)
        {
            var valid = false;
            try
            {
               var result = Convert.ToDecimal(amountText);
                if (result > 0)
                {
                    valid = true;
                }
            }
            catch (Exception)
            {
                valid = false;
            }
            return valid;
        }
        public void UpdateHistory()
        {
            _repo.historyItems = _repo.Context.TotalHistory.ToList();
            var json = new RepositoryJson();
            foreach (var historyItem in _repo.historyItems)
            {
                if (historyItem.Category == null)
                    historyItem.Category = json.categories.FirstOrDefault(cat => cat.Id == historyItem.CategoryId);
            }
        }
        public List<HistoryItem> ShowHistoryForCurrentUser()
        {
            return _repo.historyItems.FindAll(hi => hi.UserEmail == _repo._authorizedUser.Email).OrderByDescending(historyItem => historyItem.Date).ToList();
        }
        public List<HistoryItem> GetHistoryForReports()
        {
            return _repo.historyItems.FindAll(hi => hi.UserEmail == _repo._authorizedUser.Email).FindAll(f => f.Date.Month == DateTime.Now.Month);

        }
        public List<Category> SelectOnlyExpenseCategories()
        {
            var repo = new RepositoryJson();
            List<Category> some = new List<Category>();
            for (int i = 0; i < 7; i++)
            {
                some.Add(repo.categories[i]);
            }
            return some;
        }
        public string FillInTransactionComboxes(string selected_item_here)
        {
            string selection_there = null ;
            if (selected_item_here == "Cash")
            {
                selection_there = "Card";
            }
            if (selected_item_here == "Card")
            {
                selection_there = "Cash";
            }
            return selection_there;
        }
        public List<string> ComboBoxBillsItemSource()
        {
            return new List<string> { "Cash", "Card" };
        }

    }
}
