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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void LoginSubmit_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginEmailBox.Text == "alex";
            if (!(login))
            {
                MessageBox.Show("Wrong login!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }
            var _password = LoginPasswordBox.Password == "123";
            if (!(_password))
            {
                MessageBox.Show("Wrong password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            else
            {
                NavigationService.Navigate(new MainPageUI());
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
