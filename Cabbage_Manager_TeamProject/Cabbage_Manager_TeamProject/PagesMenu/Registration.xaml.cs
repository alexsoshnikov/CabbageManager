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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        DbRepository _repo = Factory.Instance.GetRepository();
        UI_Logic _ui_logic = Factory.Instance.GetUiLogic();

        public Registration()
        {
            InitializeComponent();
        }

        private void button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorization());
        }

        private void RegistrationSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _repo.RegisterUser(_ui_logic.CreateNewUser(RegisterNameBox.Text, RegisterEmailBox.Text, RegisterPasswordBox.Password));
                MessageBox.Show("You are successfully registered!");
                if (_repo.Authorize(RegisterEmailBox.Text, RegisterPasswordBox.Password))
                {
                    NavigationService.Navigate(new MainPageUI());
                }
                RegisterNameBox.Clear();
                RegisterEmailBox.Clear();
                RegisterPasswordBox.Clear();
            }
            catch
            {
                MessageBox.Show("An error occurred while trying to create a new user account." + "\n" + "Most likely the problem is that:" + "\n" + UI_Logic.errorRegistrationText + "\n" + "Extra Tips:" + "\n" + "All fields must be filled;" + "\n" + "Email address should be entered correctly(must contain @);");
                UI_Logic.errorRegistrationText = string.Empty;
            }
        }
    }
}
