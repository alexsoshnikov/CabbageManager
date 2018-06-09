using System;
using System.Collections.Generic;
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
        public Category Category { get; set; }

        public string DateRepresentation { get; set; }

        public HistoryItem()
        {
            Date = DateTime.Now;
            DateRepresentation = $"{Date:dd.MM HH:mm}";
        }
    }
}
