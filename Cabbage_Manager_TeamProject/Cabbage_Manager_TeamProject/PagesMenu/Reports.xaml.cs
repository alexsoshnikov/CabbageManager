using Cabbage_Manager_Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cabbage_Manager_TeamProject.PagesMenu
{
    /// <summary>
    /// Логика взаимодействия для Reports.xaml
    /// </summary>
    public partial class Reports : Page
    {
        static UI_Logic _ui_logic = Factory.Instance.GetUiLogic();

        public Reports()
        {
            DataContext = this;
            InitializeComponent();
            TextBlock_DayWeekMonth.Text = "Month";
            PopulateCharts();
        }

        ObservableCollection<PieSegment> collection = _ui_logic.GetInfoForMonthReport();


        void PopulateCharts()
        {
            Pie_xaml.Data = collection;
        }
        
        private void button_Month_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_DayWeekMonth.Text = "Month";
            collection = _ui_logic.GetInfoForMonthReport();
            PopulateCharts();
        }

        private void button_Week_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Day_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_DayWeekMonth.Text = "Day";
            collection = _ui_logic.GetInfoForDayReport();
            PopulateCharts();
        }
    }
}
