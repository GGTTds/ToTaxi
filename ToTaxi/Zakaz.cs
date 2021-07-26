using System;
using System.Collections.Generic;

#nullable disable

namespace ToTaxi
{
    public partial class Zakaz
    {
        public int NomerZakaza { get; set; }
        public DateTime? DateZak { get; set; }
        public int? WhoIszak { get; set; }
        public string AddresOtp { get; set; }
        public string AddresDost { get; set; }
        public int? Status { get; set; }
        public int? Transprt { get; set; }
        public int? Operator { get; set; }

        public virtual ToSatu StatusNavigation { get; set; }
        public virtual TransTt TransprtNavigation { get; set; }
        public virtual User WhoIszakNavigation { get; set; }
    }
}
