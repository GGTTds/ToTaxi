using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToTaxi
{
    interface IOperatr
    {
        public Task<bool> CloseZvon(Zvonk zv);
    }
}
