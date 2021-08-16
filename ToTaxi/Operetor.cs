using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToTaxi
{
    class Operetor : IOperatr
    {
        public async Task<bool> CloseZvon(Zvonk zv)
        {
            try
            {
                using(TaxiInDronContext v = new TaxiInDronContext())
                {
                    v.Zvonks.Remove(zv);
                    await v.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
