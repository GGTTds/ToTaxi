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
using System.Threading.Tasks;

namespace ToTaxi
{
    /// <summary>
    /// Логика взаимодействия для Prof.xaml
    /// </summary>
    public partial class Prof : Page
    {
        byte[] fot;
        public User gf23 = new User();
        public Prof()
        {
            InitializeComponent();
            FOIDG();
            f2.Visibility = Visibility.Hidden;
            f1.Visibility = Visibility.Hidden;
            f1_Copy.Visibility = Visibility.Hidden;
            m1.Visibility = Visibility.Hidden;
            m2.Visibility = Visibility.Hidden;
            ls.Background = System.Windows.Media.Brushes.Black;
        }
        public Prof(User x)
        {
            InitializeComponent();
            gf23 = x;
            ls.Background = System.Windows.Media.Brushes.Black;
            Sav_2.Visibility = Visibility.Visible;
            f2.Visibility = Visibility.Hidden;
            ThisAddNewPol();
            if (x != null)
            {
                Zap();
            }
        }
        public void Zap()
        {
            im.Text = gf23.Name;
            fam.Text = gf23.Fam;
            ot.Text = gf23.Otc;
            pas.Password = gf23.PasswordInVx;
            tel.Text = gf23.Tel;
            dat.SelectedDate = gf23.DateBird0;
            eml.Text = gf23.Email;
            fot = gf23.Photo;
            Global.VX_ID = gf23.Id;
            if (m1.IsChecked == true)
            {
                gf23.Pol = 10;
            }
            if (m2.IsChecked == true)
            {
                gf23.Pol = 11;
            }
        }

        public void FOIDG()
        {
            using (TaxiInDronContext y = new TaxiInDronContext())
            {
                var s = y.Users.Where(p => p.Id == Global._ID);
                foreach (var f in s)
                    if (f.Photo == null)
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
                                        try
                                        {
                                            File.Delete($@"Img/{f.Id}.Png");
                                            FOIDG();
                                        }
                                        catch
                                        { }
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
            if (GoSave() == true)
            {
                f2.Visibility = Visibility.Hidden;
                im.Text = gf23.Name;
                fam.Text = gf23.Fam;
                ot.Text = gf23.Otc;
                pas.Password = gf23.PasswordInVx;
                tel.Text = gf23.Tel;
                dat.SelectedDate = gf23.DateBird0;
                eml.Text = gf23.Email;
                fot = gf23.Photo;
                if (m1.IsChecked == true)
                {
                    gf23.Pol = 10;
                }
                if (m2.IsChecked == true)
                {
                    gf23.Pol = 11;
                }
                m1.Visibility = Visibility.Hidden;
                m2.Visibility = Visibility.Hidden;
                Sav_2.Visibility = Visibility.Hidden;
            }

            else { }
        }

        

        private void f1_Click(object sender, RoutedEventArgs e)
        {
            f2.Visibility = Visibility.Hidden;
            f1.Visibility = Visibility.Hidden;
            f1_Copy.Visibility = Visibility.Hidden;
            fg.Visibility = Visibility.Visible;
            m1.Visibility = Visibility.Hidden;
            m2.Visibility = Visibility.Hidden;
            Sav_2.Visibility = Visibility.Hidden;
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

        public bool GoSave()
        {
            
            if (PasEnb.PasTry(pas.Password).Length == 0)
            {
                if (ToEml.IsValidEmail(eml.Text) == true)
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

                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Некорректный email");
                }
            }
            else
            {
                MessageBox.Show(PasEnb.PasTry(pas.Password).ToString());
            }

            return false;
        }
        public void NewPolAndUpd()
        {
            
                if (gf23 == null)
                {
                    User t = new User
                    {
                        Name = im.Text,
                        Fam = fam.Text,
                        Otc = ot.Text,
                        PasswordInVx = pas.Password,
                        Tel = tel.Text,
                        DateBird0 = dat.SelectedDate,
                        Email = eml.Text,
                        Photo = fot
                    };
                    if (m1.IsChecked == true)
                    {
                        t.Pol = 10;
                    }
                    if (m2.IsChecked == true)
                    {
                        t.Pol = 11;
                    }
                    using (TaxiInDronContext v = new TaxiInDronContext())
                    {

                        v.Add(t);
                        v.SaveChanges();
                        Fram.MainFF.Navigate(new YprPol());
                    }
                }
                else
                {
                    using (TaxiInDronContext v = new TaxiInDronContext())
                    {
                        var g = v.Users.Where(p => p.Id == gf23.Id).SingleOrDefault();
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

                        fg.Visibility = Visibility.Visible;
                        f1.Visibility = Visibility.Hidden;
                        f2.Visibility = Visibility.Hidden;
                        Sav_2.Visibility = Visibility.Hidden;
                        v.SaveChanges();
                        FOIDG();
                    }
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
            if (Global.VX_ID == 0)
            {
                Fram.MainFF.Navigate(new Roul());
            }
            else
            {
                Fram.MainFF.Navigate(new Roul(Global.VX_ID));
            }
        }

        public void ThisAddNewPol()
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

        private void Sav_2_Click(object sender, RoutedEventArgs e)
        {
            if (PasEnb.PasTry(pas.Password).Length == 0)
            {
                if (ToEml.IsValidEmail(eml.Text) == true)
                {
                    NewPolAndUpd();
                }
                else
                { MessageBox.Show("Некорректный email"); }
            }
            else
            {
                MessageBox.Show(PasEnb.PasTry(pas.Password).ToString());
            }

        }
    }
}







