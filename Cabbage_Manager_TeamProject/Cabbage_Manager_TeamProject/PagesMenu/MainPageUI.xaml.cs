using Cabbage_Manager_Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Cabbage_Manager_TeamProject.PagesMenu
{

    /// <summary>
    /// Логика взаимодействия для MainPageUI.xaml
    /// </summary>
    public partial class MainPageUI : Page
    {
        static UI_Logic _ui_logic = Factory.Instance.GetUiLogic();
        DbRepository _repo = Factory.Instance.GetRepository();
        public MainPageUI()
        {

            InitializeComponent();
            LabelToolBar.Content = _repo._authorizedUser.Name;
            ComboBox_currentPay.ItemsSource = _ui_logic.FillComboboxBalanse();
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
            var historyUI = new History();

            ChangeableWindows.Content = historyUI;
        }

        public void UpdateBalance()
        {
            ComboBox_currentPay.ItemsSource = null;
            ComboBox_currentPay.ItemsSource = _ui_logic.FillComboboxBalanse();
        }

        private void Button_Adding_Expenses_Click(object sender, RoutedEventArgs e)
        {
            var addExpUI = new Adding_Expenses();
            ChangeableWindows.Content = addExpUI;
            addExpUI.HistoryInitialised1 += UpdateBalance;
        }

        private void Button_Adding_Revenues_Click(object sender, RoutedEventArgs e)
        {
            var addRevUI = new Adding_Revenues();
            ChangeableWindows.Content = addRevUI;
            addRevUI.HistoryInitialised2 += UpdateBalance;
        }

        private void Button_Transaction_Click(object sender, RoutedEventArgs e)
        {
            var trUI = new Transaction();
            ChangeableWindows.Content = trUI;
            trUI.HistoryInitialised3 += UpdateBalance;
        }

        private void Button_Reports_Click(object sender, RoutedEventArgs e)
        {
            ChangeableWindows.Content = new Reports();
        }

     
        private void Button_Change_User_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult result = MessageBox.Show("Do you really want to change the user?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question );

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
