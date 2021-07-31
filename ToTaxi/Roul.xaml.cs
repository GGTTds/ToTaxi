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
        public RoulPp ps1 = new RoulPp();
        public RoulPp ps = new RoulPp();
        public int j = 0;
        public Roul()
        {
            j = Global._ID;
            InitializeComponent();
            RolGrid();
            FunGrid();
            AdmV();
            Rol.Background = Brushes.Black;
        }
        public Roul(int x)
        {
            InitializeComponent();
            j = x;
            RolGrid();
            FunGrid();
            AdmV();
            Rol.Background = Brushes.Black;
           

        }
    
    public void RolGrid()
        {
            using(TaxiInDronContext v = new TaxiInDronContext())
            {
                var gsg = v.RoulPps.Where( p => p.WhoIsroul == j);
                datg.ItemsSource = gsg.ToList();
                ps = gsg.Where(p => p.Name == "Администратор").FirstOrDefault();
                ps1 = gsg.Where(p => p.Name == "Пользователь").FirstOrDefault();
            }
        }
        public void FunGrid()
        {
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
              datg_Copy.ItemsSource = v.FuncPps.Where(p => p.WhoIsItFunc == j).ToList();
            }
        }

        private void ls_Click(object sender, RoutedEventArgs e)
        {
            Fram.MainFF.Navigate(new Prof());
        }

        private void Rol_Click(object sender, RoutedEventArgs e)
        {
            Fram.MainFF.Navigate(new Roul());
        }

        private void ff_Click(object sender, RoutedEventArgs e)
        {
            var s = datg.SelectedItems.Cast<RoulPp>().ToList();
            using(TaxiInDronContext v = new TaxiInDronContext())
            {
                v.RoulPps.RemoveRange(s);
                v.SaveChanges();
                datg.ItemsSource = v.RoulPps.Where(p => p.WhoIsroul == j).ToList();

            }
        }

        private void ff1_Click(object sender, RoutedEventArgs e)
        {
            var s = datg_Copy.SelectedItems.Cast<FuncPp>().ToList();
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
                v.FuncPps.RemoveRange(s);
                v.SaveChanges();
                datg.ItemsSource = v.FuncPps.Where(p => p.WhoIsItFunc == j).ToList();

            }
        }
        public void AdmV()
        {
            if(Global._Rol != 1)
            {
                datg.Columns[2].Visibility = Visibility.Hidden;
                datg_Copy.Columns[2].Visibility = Visibility.Hidden;
                dde.Visibility = Visibility.Hidden;
            }
        }

        private void dde_Click(object sender, RoutedEventArgs e)
        {
            ToRoulForMod fd = new ToRoulForMod(ps,ps1);
            fd.ShowDialog();

        }
    }

}
