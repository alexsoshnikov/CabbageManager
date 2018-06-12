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
    /// Логика взаимодействия для Adding_Expenses.xaml
    /// </summary>
    public partial class Adding_Expenses : Page
    {
        DbRepository _repo = Factory.Instance.GetRepository();
        UI_Logic _ui_logic = Factory.Instance.GetUiLogic();
        public Adding_Expenses()
        {
            InitializeComponent();
            var repo = new RepositoryJson();
            ComboBox_Choose.ItemsSource = new List<string> { "Cash", "Credit Card" };
            listBox_Category.ItemsSource = repo.categories; 
        }

        private void button_TakeAmount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _ui_logic.Calculate(textBoxCalculate.Text);
                textBoxCalculate.Clear();
                textBoxCalculate.Text = result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_Ok_Click(object sender, RoutedEventArgs e)
        {
            if (_ui_logic.CheckAmountFormValid(textBoxCalculate.Text) == false)
            {
                MessageBox.Show("The number is incorrect. (It should be greater that 0.) \nTry to press <Amount> button.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ComboBox_Choose.SelectedItem == null)
                {
                    MessageBox.Show("You should choose a bill from a combobox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (listBox_Category.SelectedItem == null)
                    {
                        MessageBox.Show("You should choose a category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        _repo.AddHistoryItem(Convert.ToDecimal(textBoxCalculate.Text), ComboBox_Choose.SelectedItem as String, (listBox_Category.SelectedItem as Category).Id);
                        textBoxCalculate.Clear();
                        ComboBox_Choose.SelectedItem = null;
                        listBox_Category.SelectedItem = null;
                        MessageBox.Show("Expense added!");
                    }
                }
            }
            
        }
    }
}
