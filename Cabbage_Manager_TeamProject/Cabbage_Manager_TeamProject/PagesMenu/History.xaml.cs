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
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        UI_Logic _ui_logic = Factory.Instance.GetUiLogic();

        public History()
        {
            InitializeComponent();
            _ui_logic.UpdateHistory();
            listBox_History.ItemsSource = _ui_logic.ShowHistoryForCurrentUser();
        }
    }
}
