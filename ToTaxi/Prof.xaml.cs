using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using Image = System.Drawing.Image;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ToTaxi
{
    /// <summary>
    /// Логика взаимодействия для Prof.xaml
    /// </summary>
    public partial class Prof : Page
    {
        byte[] fot;
        public Prof()
        {
            InitializeComponent();
            FOIDG();
            f2.Visibility = Visibility.Hidden;
            f1.Visibility = Visibility.Hidden;
            f1_Copy.Visibility = Visibility.Hidden;
            m1.Visibility = Visibility.Hidden;
            m2.Visibility = Visibility.Hidden;
        }


        public void FOIDG()
        {
            using (TaxiInDronContext y = new TaxiInDronContext())
            {
                var s = y.Users.Where(p => p.Id == Global._ID);
                foreach (var f in s)
                    if(f.Photo == null)
                    { GoBack(); }
                    else
                    {

                        {
                            using (MemoryStream ms = new MemoryStream(f.Photo))
                            {
                                using (Image img = Image.FromStream(ms))
                                {
                                    try
                                    {
                                        img.Save($@"Img/{f.Id}.Png");
                                        var path = $@"Img/{f.Id}.Png";
                                        Bitmap bmp = new Bitmap(path);
                                        MemoryStream ms1 = new MemoryStream();
                                        bmp.Save(ms1, ImageFormat.Png);
                                        ms1.Position = 0;
                                        BitmapImage bi = new BitmapImage();
                                        bi.BeginInit();
                                        bi.StreamSource = ms1;
                                        bi.EndInit();
                                        w1.Source = bi;
                                    }
                                    catch
                                    {
                                        File.Delete($@"Img/{f.Id}.Png");
                                        FOIDG();
                                    }
                                }
                            }
                        }

                    GoBack();

                }

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fg.Visibility = Visibility.Hidden;
            f1.Visibility = Visibility.Visible;
            f2.Visibility = Visibility.Visible;
            f1_Copy.Visibility = Visibility.Visible;
            m1.Visibility = Visibility.Visible;
            m2.Visibility = Visibility.Visible;
            fam.IsReadOnly = false;
            im.IsReadOnly = false;
            ot.IsReadOnly = false;
            eml.IsReadOnly = false;
            tel.IsReadOnly = false;
            dat.IsEnabled = true;
            pas.IsEnabled = true;
            poll.IsReadOnly = false;
        }

        private void f2_Click(object sender, RoutedEventArgs e)
        {
            f2.Visibility = Visibility.Hidden;
            f1.Visibility = Visibility.Hidden;
            f1_Copy.Visibility = Visibility.Hidden;
            fg.Visibility = Visibility.Visible;
            m1.Visibility = Visibility.Hidden;
            m2.Visibility = Visibility.Hidden;
            GoSave();

        }

        private void f1_Click(object sender, RoutedEventArgs e)
        {
            f2.Visibility = Visibility.Hidden;
            f1.Visibility = Visibility.Hidden;
            f1_Copy.Visibility = Visibility.Hidden;
            fg.Visibility = Visibility.Visible;
            m1.Visibility = Visibility.Hidden;
            m2.Visibility = Visibility.Hidden;
            GoBack();
        }

        public void GoBack()
        {
            using (TaxiInDronContext v = new TaxiInDronContext())
            {
                var s = v.Users.Where(p => p.Id == Global._ID);
                foreach (var f in s)
                {
                    fam.Text = f.Fam;
                    im.Text = f.Name;
                    ot.Text = f.Otc;
                    eml.Text = f.Email;
                    tel.Text = f.Tel;
                    dat.SelectedDate = f.DateBird0;
                    pas.Password = f.PasswordInVx;
                    if (f.Pol == 10)
                    {
                        poll.Text = "Мужчина";
                        m1.IsChecked = true;
                    }
                    else
                    {
                        poll.Text = "Женщина";
                        m2.IsChecked = true;
                    }
                    fam.IsReadOnly = true;
                    im.IsReadOnly = true;
                    ot.IsReadOnly = true;
                    eml.IsReadOnly = true;
                    tel.IsReadOnly = true;
                    dat.IsEnabled = false;
                    pas.IsEnabled = false;
                    poll.IsReadOnly = true;
                }
            }
        }

        public void GoSave()
        {
            StringBuilder B = new StringBuilder();
            if (pas.Password.Length < 6 )
            {
                B.Append("Пароль слишком короткий\n");
            }
            if(pas.Password.Any(char.IsUpper) == false)
            {
                B.Append("Пароль должен содержать хотябы одну букву верхнего регистра\n");
            }
            if(pas.Password.Any(Char.IsLower) == false)
            {
                B.Append("Пароль должен содержать хотябы одну букву нижнего регистра\n");
            }
            if(IsValidEmail(eml.Text) == false )
            {
               B.Append(" Введеите корректнкю почту\n");
            }
            if (B.Length == 0)
            {
                fam.IsReadOnly = true;
                im.IsReadOnly = true;
                ot.IsReadOnly = true;
                eml.IsReadOnly = true;
                tel.IsReadOnly = true;
                dat.IsEnabled = false;
                pas.IsEnabled = false;
                poll.IsReadOnly = true;
                using (TaxiInDronContext v = new TaxiInDronContext())
                {
                    var g = v.Users.Where(p => p.Id == Global._ID).SingleOrDefault();
                    g.Name = im.Text;
                    g.Fam = fam.Text;
                    g.Otc = ot.Text;
                    g.PasswordInVx = pas.Password;
                    g.Tel = tel.Text;
                    g.DateBird0 = dat.SelectedDate;
                    g.Email = eml.Text;
                    g.Photo = fot;
                    if (m1.IsChecked == true)
                    {
                        g.Pol = 10;
                    }
                    if (m2.IsChecked == true)
                    {
                        g.Pol = 11;
                    }
                    v.SaveChanges();
                    FOIDG();
                }
            }
            else
            {
                MessageBox.Show(B.ToString());
            }


        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void f1_Copy_Click(object sender, RoutedEventArgs e)
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

        private void m2_Click(object sender, RoutedEventArgs e)
        {
            m1.IsChecked = false;
        }

        private void m1_Click(object sender, RoutedEventArgs e)
        {
            m2.IsChecked = false;
        }

        private void ls_Click(object sender, RoutedEventArgs e)
        {
            Fram.MainFF.Navigate(new Prof());
        }

        private void Rol_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}







