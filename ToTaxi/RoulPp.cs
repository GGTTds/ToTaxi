﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ToTaxi
{
    public partial class RoulPp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? WhoIsroul { get; set; }

        public virtual User WhoIsroulNavigation { get; set; }
    }
}
