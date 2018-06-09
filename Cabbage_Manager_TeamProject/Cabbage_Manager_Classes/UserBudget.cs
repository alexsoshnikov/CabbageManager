using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    class UserBudget
    {
        public decimal TotalBalanse { get; set; }
        public decimal CashSum { get; set; }
        public decimal CreditCardSum { get; set; }

        public List<HistoryItem> History { get; set; }
        public List<HistoryItem> IncomeStory { get; set; }
        public List<HistoryItem> ExpenseStory { get; set; }

        //public List<MonthBudget> Mounthly { get; set; }
        public UserBudget()
        {
            History = new List<HistoryItem>();
            //Mounthly = new List<MonthBudget>();
            IncomeStory = History.FindAll(i => i.Type == "I");
            ExpenseStory = History.FindAll(i => i.Type == "E");
            TotalBalanse = 0;
            CashSum = 0;
            CreditCardSum = 0;
        }
    }
}
