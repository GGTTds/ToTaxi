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

        private void vx_Click(object sender, RoutedEventArgs e)
        {
            using(TaxiInDronContext re = new TaxiInDronContext())
            {
                var s = re.Users.Where(p => p.LogininVx == Log1.Text && p.PasswordInVx == Pas1.Password);
                if ( s == null|| Pas1.Password.Length == 0)
                {
                    MessageBox.Show(" Введены некоректные данные", " Ошибека");
                }
                else
                {
                    foreach (var b in s)
                    {
                        Global._ID = b.Id;
                    }
                    MainMenu d = new MainMenu();
                    d.Show();
                    this.Close();
                }
                if(Cheak.IsChecked == true)
                {
                    using(StreamWriter rty = new StreamWriter("login.ttr"))
                    {
                        rty.WriteLine(Log1.Text);
                    }
                }
                else
                {
                    using (StreamWriter rty = new StreamWriter("login.ttr"))
                    {
                        rty.WriteLine("");
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

        private void Window_Activated(object sender, EventArgs e)
        {
            using (StreamReader we = new StreamReader("login.ttr"))
            {
                DF();
            }
        }
    
    public void DF()
        {
            using(StreamReader we = new StreamReader("login.ttr"))
            {
                if (we != null)
                {
                    Log1.Text = we.ReadLine();
                }
            }
        }
    
    }
}
