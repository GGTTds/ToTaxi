using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ToTaxi
{
    public class SaveAndCreateAndUpdateUser : IAdmIntf
    {
        public bool UpdThisProf(User r)
        {
            try
            {
                using (TaxiInDronContext v = new TaxiInDronContext())
                {
                    var g = v.Users.Where(p => p.Id == r.Id).SingleOrDefault();
                    g.Id = r.Id;
                    g.Zakazs = r.Zakazs;
                    g.Name = r.Name;
                    g.Fam = r.Fam;
                    g.Otc = r.Otc;
                    g.PasswordInVx = r.PasswordInVx;
                    g.Photo = r.Photo;
                    g.Pol = r.Pol;
                    g.DateBird0 = r.DateBird0;
                    g.Email = r.Email;
                    g.FuncPp = r.FuncPp;
                    g.FuncPps = r.FuncPps;
                    g.LogininVx = r.LogininVx;
                    g.Roul = r.Roul;
                    g.RoulPps = r.RoulPps;
                    g.Tel = r.Tel;
                    v.Users.Update(g);
                    v.SaveChanges();
                    return true;

                }
            }
            catch { return false; }
            }


        public bool AddNewPol(User r)
        {
            try
            {
                using (TaxiInDronContext v = new TaxiInDronContext())
                {
                    v.Users.Add(r);
                    v.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

    }
}
