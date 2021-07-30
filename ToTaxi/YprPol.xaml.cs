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
            Red();

        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            Fram.MainFF.Navigate(new Prof((sender as Button).DataContext as User));
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var f = dd.SelectedItems.Cast<User>().ToList();
            using(TaxiInDronContext v = new TaxiInDronContext())
            {
                v.RemoveRange(f);
                v.SaveChanges();
                GoTabl();
            }
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
            if(ff1.Text != null)
            {
                    dd.ItemsSource = v1.Where(p => p.Fam.Contains(ff1.Text)).ToList();
            }
            else 
            {
                dd.ItemsSource = v1;
            }

        }

        

        private void ff1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ToTextBox();
        }

        private void dd1_TextInput(object sender, TextCompositionEventArgs e)
        {
            ToTextBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fram.MainFF.Navigate(new Prof(null));
        }
    }

}
