﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public class UserBudget
    {
        public int Id { get; set; }
        public decimal TotalBalanse { get; set; }
        public decimal CashSum { get; set; }
        public decimal CreditCardSum { get; set; }


        public UserBudget()
        {
            TotalBalanse = 0;
            CashSum = 0;
            CreditCardSum = 0;
        }
    }
}
