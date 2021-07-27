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

namespace ToTaxi
{
    /// <summary>
    /// Логика взаимодействия для Prof.xaml
    /// </summary>
    public partial class Prof : Page
    {
        public Prof()
        {
            InitializeComponent();
            FOIDG();
        }


        public void FOIDG()
        {
            using (TaxiInDronContext y = new TaxiInDronContext())
            {
                var s = y.Users.Where(p => p.Id == Global._ID);
                foreach (var f in s)
                {
                    using (MemoryStream ms = new MemoryStream(f.Photo))
                    {
                        using (Image img = Image.FromStream(ms))
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
                    }

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
                    }
                    else
                    {
                        poll.Text = "Женщина";
                    }
                
                }
            
            }
        
        }
   
    
    
           
    
    
    
    }
}
          
    
    

