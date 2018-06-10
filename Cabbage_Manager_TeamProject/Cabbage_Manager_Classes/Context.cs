using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserBudget> UserBudgets { get; set; }
        public DbSet<HistoryItem> TotalHistory { get; set; }

        public Context() : base("TeamProjectdb")
        { }
    }
}
