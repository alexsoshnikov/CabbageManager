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
using System.Windows.Threading;

namespace Cabbage_Manager_TeamProject.PagesMenu
{
    /// <summary>
    /// Логика взаимодействия для MainPageUI.xaml
    /// </summary>
    public partial class MainPageUI : Page
    {
        public MainPageUI()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(10000);
            dispatcherTimer.Start();
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            CurrentTime.Content = DateTime.Now.ToString("dd/MM HH:mm");
        }

        private void Button_History_Click(object sender, RoutedEventArgs e)
        {
            ChangeableWindows.Content = new History();
        }

        private void Button_Adding_Expenses_Click(object sender, RoutedEventArgs e)
        {
            ChangeableWindows.Content = new Adding_Expenses();
        }

        private void Button_Adding_Revenues_Click(object sender, RoutedEventArgs e)
        {
            ChangeableWindows.Content = new Adding_Revenues();
        }

        private void Button_Transaction_Click(object sender, RoutedEventArgs e)
        {
            ChangeableWindows.Content = new Transaction();
        }

        private void Button_Reports_Click(object sender, RoutedEventArgs e)
        {
            ChangeableWindows.Content = new Reports();
        }

        private void Button_Change_User_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to change the user?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new Autorization());
            }
            else
            {
                NavigationService.Navigate(new MainPageUI());
            }

        }
    }
}
