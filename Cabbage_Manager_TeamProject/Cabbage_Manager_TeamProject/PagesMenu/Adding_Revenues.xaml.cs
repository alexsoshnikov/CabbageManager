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
    /// Логика взаимодействия для Adding_Revenues.xaml
    /// </summary>
    public partial class Adding_Revenues : Page
    {
        public Adding_Revenues()
        {
            InitializeComponent();
        }

        private void button_TakeAmount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxCalculate.Text.Contains('+') || textBoxCalculate.Text.Contains('-'))
                {
                    string[] sum = textBoxCalculate.Text.Split('+');
                    for (int j = 0; j < sum.Length; j++)
                    {
                        if (sum[j].Contains('-'))
                        {
                            string[] devis = sum[j].Split('-');
                            double f = Convert.ToDouble(devis[0]);
                            for (int i = 1; i < devis.Length; i++)
                            {
                                f -= Convert.ToDouble(devis[i]);
                            }
                            sum[j] = Convert.ToString(f);
                        }

                    }

                    double c = 0;
                    for (int i = 0; i < sum.Length; i++)
                    {
                        c += Convert.ToDouble(sum[i]);
                    }


                    textBoxCalculate.Clear();
                    textBoxCalculate.Text = c.ToString();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error!","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
