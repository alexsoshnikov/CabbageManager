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
            collection = _ui_logic.GetInfoForMonthReport();
            if (_ui_logic.CheckIfAllValuesZero(collection))
            {
                TextBlock_DayWeekMonth.Text = "No info for this period found";
            }
            else
            {
                TextBlock_DayWeekMonth.Text = "Month";
            }
            PopulateCharts();
            listBox_informationReports.ItemsSource = _ui_logic.FillListBoxMonth();
        }

        ObservableCollection<PieSegment> collection = _ui_logic.GetInfoForMonthReport();
        

        void PopulateCharts()
        {
            Pie_xaml.Data = collection;
        }
        
        private void button_Month_Click(object sender, RoutedEventArgs e)
        {
            collection = _ui_logic.GetInfoForMonthReport();
            if (_ui_logic.CheckIfAllValuesZero(collection))
            {
                TextBlock_DayWeekMonth.Text = "No info for this period found";
            }
            else
                TextBlock_DayWeekMonth.Text = "Month";
            PopulateCharts();
            listBox_informationReports.ItemsSource = null;
            listBox_informationReports.ItemsSource = _ui_logic.FillListBoxMonth();
        }

        private void button_Week_Click(object sender, RoutedEventArgs e)
        {
            collection = _ui_logic.GetInfoForWeekReport();
            if (_ui_logic.CheckIfAllValuesZero(collection))
            {
                TextBlock_DayWeekMonth.Text = "No info for this period found";
            }
            else
                TextBlock_DayWeekMonth.Text = "This Week (since Monday)";
            PopulateCharts();
            listBox_informationReports.ItemsSource = null;
            listBox_informationReports.ItemsSource = _ui_logic.FillListBoxWeek();
        }

        private void button_Day_Click(object sender, RoutedEventArgs e)
        {
            collection = _ui_logic.GetInfoForDayReport();
            if (_ui_logic.CheckIfAllValuesZero(collection))
            {
                TextBlock_DayWeekMonth.Text = "No info for this period found";
            }
            else
                TextBlock_DayWeekMonth.Text = "Today";
            PopulateCharts();
            listBox_informationReports.ItemsSource = null;
            listBox_informationReports.ItemsSource = _ui_logic.FillListBoxDay();
        }
    }
}
