using System;
using System.Collections.Generic;
using System.Text;

namespace ToTaxi
{
    public interface IAdmIntf
    {
        public bool UpdThisProf(User r);
        public bool AddNewPol(User r);
    }
}
