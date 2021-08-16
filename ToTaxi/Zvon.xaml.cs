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
    /// Логика взаимодействия для Zvon.xaml
    /// </summary>
    public partial class Zvon : Page
    {
        public Zvon()
        {
            InitializeComponent();
            ToGridData();
        }

       public void ToGridData()
        {
            using(TaxiInDronContext v = new TaxiInDronContext())
            {
                dd.ItemsSource = v.Zvonks.ToList();
            }
        }

        private async void red_Click(object sender, RoutedEventArgs e)
        {
            Operetor r = new Operetor();
            await r.CloseZvon((sender as Button).DataContext as Zvonk);
            ToGridData();
        }
    }
}
