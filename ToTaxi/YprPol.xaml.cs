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
        List<User> v1;
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
                v1 = v.Users.ToList();
                dd.ItemsSource = v1;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ff1.Text = null;
        }
        private void dd1_GotFocus(object sender, RoutedEventArgs e)
        {
            dd1.Text = null;
        }

        public void Red()
        {
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
                var t = v.FuncPps.Where(p => p.WhoIsItFunc == Global._ID);
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
    
        public void ToTextBox()
        {
            if(ff1.Text.Length > 0)
            {
                using( TaxiInDronContext g = new TaxiInDronContext())
                {
                    dd.ItemsSource = g.Users.Where(p => p.Fam.Contains(ff1.Text)).ToList();
                }
               
            }
            if (ff1.Text.Length == 0)
            {
                dd.ItemsSource = v1;
            }
            if (dd1.Text.Length > 0)
            {
                using (TaxiInDronContext g = new TaxiInDronContext())
                {
                    dd.ItemsSource = g.Users.Where(p => p.DateBird0.ToString().Contains(ff1.Text)).ToList();
                }
            }
            if (ff1.Text == null)
            {
                dd.ItemsSource = v1;
            }

        }

        private void ff1_KeyDown(object sender, KeyEventArgs e)
        {
            ToTextBox();
        }

      
    }

}
