using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_TeamProject.PagesMenu.Charts
{
    internal class PieDataCollection<T> : ObservableCollection<T> where T : PieSegment
    {
        public string CollectionName { get; set; }
    }
}
