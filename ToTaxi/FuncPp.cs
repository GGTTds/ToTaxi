using System;
using System.Collections.Generic;

#nullable disable

namespace ToTaxi
{
    public partial class FuncPp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? WhoIsItFunc { get; set; }

        public virtual User WhoIsItFuncNavigation { get; set; }
    }
}
