using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace ToTaxi
{
    /// <summary>
    /// Логика взаимодействия для YprPol.xaml
    /// </summary>
    public partial class YprPol : Page
    {
        public YprPol()
        {
            InitializeComponent();
            GoTabl();


        }

        private void red_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        public void GoTabl()
        {
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
                dd.ItemsSource = v.Users.ToList();
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ff1.Text = null;
        }

        public void Red()
        {
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
                var t = v.RoulPps.Where(p => p.WhoIsroul == Global._ID);
                foreach (var y in t)
                {
                    if (y.Name == "Управление пользователями")
                    {
                        dd.Columns[4].Visibility = Visibility.Visible;
                        dd.Columns[5].Visibility = Visibility.Visible;
                    }
                }
            }
           
        }
    
        
    }

}
