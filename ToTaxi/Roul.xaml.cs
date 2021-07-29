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
    /// Логика взаимодействия для Roul.xaml
    /// </summary>
    public partial class Roul : Page
    {
        public Roul()
        {
            InitializeComponent();
            RolGrid();
            FunGrid();
        }
    
    public void RolGrid()
        {
            using(TaxiInDronContext v = new TaxiInDronContext())
            {
                datg.ItemsSource = v.RoulPps.Where( p => p.WhoIsroul == Global._ID).ToList();
            }
        }
        public void FunGrid()
        {
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
              datg_Copy.ItemsSource = v.FuncPps.Where(p => p.WhoIsItFunc == Global._ID).ToList();
            }
        }

        private void ls_Click(object sender, RoutedEventArgs e)
        {
            Fram.MainFF.Navigate(new Prof());
        }

        private void Rol_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ff_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
