using System;
using System.Collections.Generic;

#nullable disable

namespace ToTaxi
{
    public partial class ToSatu
    {
        public ToSatu()
        {
            Zakazs = new HashSet<Zakaz>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Zakaz> Zakazs { get; set; }
    }
}
