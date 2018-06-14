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
    /// Логика взаимодействия для Transaction.xaml
    /// </summary>
    public partial class Transaction : Page
    {
        DbRepository _repo = Factory.Instance.GetRepository();
        UI_Logic _ui_logic = Factory.Instance.GetUiLogic();
        public event Action HistoryInitialised3;
        public Transaction()
        {
            InitializeComponent();
            ComboBox_From.ItemsSource = _ui_logic.ComboBoxBillsItemSource();
            ComboBox_To.ItemsSource = _ui_logic.ComboBoxBillsItemSource();
        }

        private void ComboBox_From_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox_To.SelectedItem = _ui_logic.FillInTransactionComboxes((ComboBox_From.SelectedItem as String));
        }

        private void ComboBox_To_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox_From.SelectedItem = _ui_logic.FillInTransactionComboxes((ComboBox_To.SelectedItem as String));
        }

        private void button_Ok_Click(object sender, RoutedEventArgs e)
        {
            if (_ui_logic.CheckAmountFormValid(textBoxAmountTransaction.Text) == false)
            {
                MessageBox.Show("The number is incorrect. (It should be greater that 0.) \nTry to press <Count> button.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ComboBox_From.SelectedItem == null)
                {
                    MessageBox.Show("You should choose a bill from a combobox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (ComboBox_To.SelectedItem == null)
                    {
                        MessageBox.Show("You should choose a bill from a combobox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        _repo.AddHisItem_SpecialForTransaction(Convert.ToDecimal(textBoxAmountTransaction.Text), ComboBox_From.SelectedItem as String, ComboBox_To.SelectedItem as String);
                        textBoxAmountTransaction.Clear();
                        ComboBox_From.SelectedItem = null;
                        ComboBox_To.SelectedItem = null;
                        NavigationService.Navigate(new History());
                        HistoryInitialised3?.Invoke();
                    }
                }
            }
        }

        private void button_TakeAmount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _ui_logic.Calculate(textBoxAmountTransaction.Text);
                textBoxAmountTransaction.Clear();
                textBoxAmountTransaction.Text = result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
