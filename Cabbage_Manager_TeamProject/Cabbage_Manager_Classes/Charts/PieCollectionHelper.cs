using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public static class PieCollectionHelper
    {
        public static double GetTotal(this ObservableCollection<PieSegment> collection)
        {
            return collection.Sum((a) => { return a.Value; });
        }
    }
}
