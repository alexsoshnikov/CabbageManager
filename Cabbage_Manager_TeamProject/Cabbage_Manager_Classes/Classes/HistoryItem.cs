using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public class HistoryItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public string UserEmail { get; set; }
        public virtual UserBudget UserBudget { get; set; }
        [NotMapped]
        public Category Category { get; set; }

        public string DateRepresentation { get; set; }

        public HistoryItem()
        {
            Date = DateTime.Now;
            DateRepresentation = $"{Date:dd.MM HH:mm}";
        }
    }
}
