using Cabbage_Manager_Classes;
using System;
using System.Collections.Generic;
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
        UI_Logic _ui_logic = Factory.Instance.GetUiLogic();

        public Reports()
        {
            DataContext = this;
            InitializeComponent();
            PopulateCharts();
        }
        List<PieDataCollection<PieSegment>> collectionList = new List<PieDataCollection<PieSegment>>();

        PieDataCollection<PieSegment> collection;


        void PopulateCharts()
        {
            

            collection = new PieDataCollection<PieSegment>();
            collection.Add(new PieSegment { Color = (Color)ColorConverter.ConvertFromString("#FF7F50"), Value = 100, Name = "Fruites" });
            collection.Add(new PieSegment { Color = (Color)ColorConverter.ConvertFromString("#DB7093"), Value = 100, Name = "Fruites" });
            collection.Add(new PieSegment { Color = Colors.Red, Value = 10, Name = "Vegetables" });
            collection.Add(new PieSegment { Color = Colors.DarkCyan, Value = 18, Name = "Meat" });
            collection.Add(new PieSegment { Color = Colors.Wheat, Value = 20, Name = "Grains" });
            collection.Add(new PieSegment { Color = Colors.Gold, Value = 8, Name = "Sweets" });

            Pie_xaml.Data = collection;

        }

        //Color = (Color) ColorConverter.ConvertFromString("#FF7F50")
        private void button_Month_Click(object sender, RoutedEventArgs e)
        {

            //var collectionListHI = _ui_logic.GetHistoryForReports().ConvertAll(hi => )
            

        }
    }
}
