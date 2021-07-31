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
using System.IO;

namespace ToTaxi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void vx_Click(object sender, RoutedEventArgs e)
        {
            using (TaxiInDronContext re = new TaxiInDronContext())
            {
                var s = re.Users.Where(p => p.LogininVx == Log1.Text && p.PasswordInVx == Pas1.Password);
                foreach (var b in s)
                {
                    Global._ID = b.Id;
                }
                var s1 = re.RoulPps.Where(p => p.WhoIsroul == Global._ID);
                foreach (var t in s1)
                {
                    if (t.Name == "Администратор")
                    {
                        Global._Rol = 1;
                    }
                }
                if (Global._ID == 0)
                {
                    MessageBox.Show(" Введены некоректные данные", " Ошибка");
                    Pas1.Password = null;
                }
                else
                {

                    MainMenu d = new MainMenu();
                    d.Show();
                    this.Close();
                }
                if (Cheak.IsChecked == true)
                {
                    using (StreamWriter rty = new StreamWriter("login.ttr"))
                    {
                       await rty.WriteLineAsync(Log1.Text);
                    }
                }
                else
                {
                    using (StreamWriter rty = new StreamWriter("login.ttr"))
                    {
                        await rty.WriteLineAsync("");
                    }
                }

            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Registr er = new Registr();
            er.Show();
            this.Close();
        }

        private async void Window_Activated(object sender, EventArgs e)
        {
            using (StreamReader we = new StreamReader("login.ttr"))
            {
                if (we != null)
                {
                     Log1.Text = we.ReadLineAsync().Result;
                }
            }
        }

       

    }
}
