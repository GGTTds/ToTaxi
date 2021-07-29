using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Text;

namespace ToTaxi
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        User _user = new User();
        byte[] fot;
        int? pol4 = null;
        public Registr()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
                StringBuilder de = new StringBuilder();
                if (im.Text.Length == 0)
                {
                    de.Append("Введиете имя \n");
                }
                if (fam.Text.Length == 0)
                {
                    de.Append("Введиете фамилию \n");
                }
                if (ot_.Text.Length == 0)
                {
                    de.Append("Введиете отчество \n");
                }
                if (tel.Text.Length == 0)
                {
                    de.Append("Введиете телефон \n");
                }
                if (eml.Text.Length == 0)
                {
                    de.Append("Введиете email \n");
                }
                if (Log.Text.Length == 0)
                {
                    de.Append("Введиете логин \n");
                }
                if (ps1.Password.Length == 0)
                {
                    de.Append("Введиете пароль \n");
                }
                if (de.Length == 0)
                {
                    try
                    {
                        _user.Name = im.Text;
                        _user.Fam = fam.Text;
                        _user.Otc = ot_.Text;
                        _user.DateBird0 = datt.SelectedDate;
                        _user.Email = eml.Text;
                        _user.FuncPp = null;
                        _user.FuncPpNavigation = null;
                        _user.LogininVx = Log.Text;
                        _user.PasswordInVx = ps1.Password;
                        _user.Pol = pol4;
                        _user.Roul = null;
                        _user.Photo = fot;
                        v.Users.Add(_user);
                        v.SaveChanges();
                        MessageBox.Show("Регистрация завершина", "Успешно");
                        this.Close();
                        MainWindow we = new MainWindow();
                        we.Show();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    MessageBox.Show(de.ToString());
                }
            }
        }

        private void Naz_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fd = new MainWindow();
            fd.Show();
            this.Close();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (jjj.IsChecked == true)
            {
                jjj.IsChecked = false;
            }
            pol4 = 10;

        }

        private void CheckBox_Click_1(object sender, RoutedEventArgs e)
        {
            if (mmm.IsChecked == true)
            {
                mmm.IsChecked = false;
            }
            pol4 = 11;
        }

        private void ff_Click(object sender, RoutedEventArgs e)
        {
            GoFoto();
        }
        public void GoFoto()
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (dia.ShowDialog() == true)
            {
                fot = File.ReadAllBytes(dia.FileName);
            }
            if (fot != null)
            {
                MessageBox.Show("Фото добавлено");
            }
        }


    }
}
