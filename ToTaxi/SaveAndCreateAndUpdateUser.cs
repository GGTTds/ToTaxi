using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ToTaxi
{
    public class SaveAndCreateAndUpdateUser : IAdmIntf
    {
        public async Task<bool> UpdThisProf(User r)
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
                    await v.SaveChangesAsync();
                    return true;

                }
            }
            catch { return false; }
            }


        public async Task<bool> AddNewPol(User r)
        {
            try
            {
                using (TaxiInDronContext v = new TaxiInDronContext())
                {
                    v.Users.Add(r);
                    await v.SaveChangesAsync();
                    return true;
                }
            }
            catch { return false; }
        }

    }
}
