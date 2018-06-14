using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

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
        public decimal PlusOrMinusMoneyInTotalBalanse(HistoryItem _hi)
        {
            decimal summ_part = 0;
            if (_hi.CategoryId<9)
            {
                summ_part = Decimal.Negate(_hi.Amount);
            }
            if (_hi.CategoryId == 51 || _hi.CategoryId == 52)
            {
                summ_part = _hi.Amount;
            }
            return summ_part;
        }
        public decimal GetTotalBalance()
        {
            decimal summ = 0;
            foreach (var historyItem in ShowHistoryForCurrentUser())
            {
                summ += PlusOrMinusMoneyInTotalBalanse(historyItem);
            }
            return summ;
        }
        public decimal GetCashBalance()
        {
            decimal summ = 0;
            foreach (var historyItem in ShowHistoryForCurrentUser())
            {
                summ += PlusOrMinusMoneyInCashBalance(historyItem);
            }
            return summ;
        }
        public decimal PlusOrMinusMoneyInCashBalance(HistoryItem _hi)
        {
            decimal summ_part = 0;
            if (_hi.CategoryId < 9)
            {
                if (_hi.Type == "Cash")
                {
                    summ_part = Decimal.Negate(_hi.Amount);
                }
            }
            if (_hi.CategoryId == 51)
            {
                summ_part = _hi.Amount;
     
            }
            if (_hi.CategoryId == 61)
            {
                summ_part = Decimal.Negate(_hi.Amount);
            }
            if (_hi.CategoryId == 62)
            {
                summ_part = _hi.Amount;
            }
            return summ_part;
        }
        public decimal GetCardBalance()
        {
            decimal summ = 0;
            foreach (var historyItem in ShowHistoryForCurrentUser())
            {
                summ += PlusOrMinusMoneyInCardBalance(historyItem);
            }
            return summ;
        }
        public decimal PlusOrMinusMoneyInCardBalance(HistoryItem _hi)
        {
            decimal summ_part = 0;
            if (_hi.CategoryId < 9)
            {
                if (_hi.Type == "Card")
                {
                    summ_part = Decimal.Negate(_hi.Amount);
                }
            }
            if (_hi.CategoryId == 52)
            {
                summ_part = _hi.Amount;
            }
            if (_hi.CategoryId == 62)
            {
                summ_part = Decimal.Negate(_hi.Amount);
            }
            if (_hi.CategoryId == 61)
            {
                summ_part = _hi.Amount;
            }
            return summ_part;
        }
        public List<string> FillComboboxBalanse()
        {
            List<string> info = new List<string>();
            info.Add("Total Balance: " + GetTotalBalance().ToString());
            info.Add("Cash Balance: " + GetCashBalance().ToString());
            info.Add("Card Balance: " + GetCardBalance().ToString());
            return info;
        }

        public List<HistoryItem> RetunOnlyExpenses()
        {
            UpdateHistory();
            List<HistoryItem> exp = new List<HistoryItem>();
            foreach (var his_it in ShowHistoryForCurrentUser())
            {
                if (his_it.CategoryId < 9)
                {
                    exp.Add(his_it);
                }
            }
            return exp;
        }
        public List<HistoryItem> GetHistoryForReportsMonth()
        {
            return RetunOnlyExpenses().FindAll(hi => hi.UserEmail == _repo._authorizedUser.Email).FindAll(f => f.Date.Month == DateTime.Now.Month);
        }
        public List<HistoryItem> GetHistoryForReportsWeek()
        {
            //return RetunOnlyExpenses().FindAll(hi => hi.UserEmail == _repo._authorizedUser.Email).FindAll(f => f.Date.Month == DateTime.Now.);
            return null;
        }
        public List<HistoryItem> GetHistoryForReportsDay()
        {
            return RetunOnlyExpenses().FindAll(hi => hi.UserEmail == _repo._authorizedUser.Email).FindAll(f => f.Date.Day == DateTime.Now.Day);
        }
        public double CountSummForCategories(List<HistoryItem> history, int category)
        {
            double value = Convert.ToDouble(history.FindAll(h => h.CategoryId == category).Sum(h => h.Amount));
            return value;
        }

        public ObservableCollection<PieSegment> GetInfoForMonthReport()
        {
            ObservableCollection<PieSegment> collection = new ObservableCollection<PieSegment>();
            foreach (var category in SelectOnlyExpenseCategories())
            {
                collection.Add(new PieSegment { Color = (Color)ColorConverter.ConvertFromString(category.ColourCode), Value = CountSummForCategories(GetHistoryForReportsMonth(), category.Id), Name = category.Name });
            }
            return collection;
        }
        public ObservableCollection<PieSegment> GetInfoForDayReport()
        {
            ObservableCollection<PieSegment> collection = new ObservableCollection<PieSegment>();
            foreach (var category in SelectOnlyExpenseCategories())
            {
                collection.Add(new PieSegment { Color = (Color)ColorConverter.ConvertFromString(category.ColourCode), Value = CountSummForCategories(GetHistoryForReportsDay(), category.Id), Name = category.Name });
            }
            return collection;
        }
    }
}
