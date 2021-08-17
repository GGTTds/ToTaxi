using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToTaxi
{
    public interface IAdmIntf
    {
        public Task<bool> UpdThisProf(User r);
        public Task<bool> AddNewPol(User r);
    }
}
