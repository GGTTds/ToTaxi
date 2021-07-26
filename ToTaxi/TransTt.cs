using System;
using System.Collections.Generic;

#nullable disable

namespace ToTaxi
{
    public partial class TransTt
    {
        public TransTt()
        {
            Zakazs = new HashSet<Zakaz>();
        }

        public int Id { get; set; }
        public string Mark { get; set; }
        public DateTime? YearPr { get; set; }
        public int? RegisNom { get; set; }
        public DateTime? DateReg { get; set; }
        public DateTime? DateSpis { get; set; }

        public virtual ICollection<Zakaz> Zakazs { get; set; }
    }
}
