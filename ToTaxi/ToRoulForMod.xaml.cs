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
using System.Windows.Shapes;

namespace ToTaxi
{
    /// <summary>
    /// Логика взаимодействия для ToRoulForMod.xaml
    /// </summary>
    public partial class ToRoulForMod : Window
    {
        public int A = 0;
        public int P = 0;
        public ToRoulForMod(RoulPp sg, RoulPp sg2)
        {
            InitializeComponent();
            WhoIS(sg, sg2);
        }

        private void bb_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fs_Click(object sender, RoutedEventArgs e)
        {
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
                    if (A == 0)
                    {
                        if (s1.IsChecked == true)
                        {
                            RoulPp t = new RoulPp
                            {
                                Name = "Администратор",
                                WhoIsroul = Global.VX_ID
                            };
                            v.RoulPps.Add(t);
                            v.SaveChanges();
                        }
                        if (P == 0)
                        {
                            if (s2.IsChecked == true)
                            {
                                RoulPp t = new RoulPp
                                {
                                    Name = "Пользователь",
                                    WhoIsroul = Global.VX_ID
                                };
                                v.RoulPps.Add(t);
                                v.SaveChanges();

                            }
                        }
                    }
                this.Close();
                Fram.MainFF.Navigate(new Roul(Global.VX_ID));
                    
            }
            
        }

        public void WhoIS(RoulPp sg1, RoulPp sg12)
        {
            if (sg1 != null)
            {
                if (sg1.Name == "Администратор")
                {
                    s1.IsChecked = true;
                    A = 1;
                }
            }
            if (sg12 != null)
            {
                if (sg12.Name == "Пользователь")
                {
                    s2.IsChecked = true;
                    P = 1;
                }
            }
            
        }
    
    }
}
