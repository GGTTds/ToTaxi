using System;
using System.Collections.Generic;

#nullable disable

namespace ToTaxi
{
    public partial class PolPol
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual User IdNavigation { get; set; }
    }
}
