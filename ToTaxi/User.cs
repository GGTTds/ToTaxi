using System;
using System.Collections.Generic;

#nullable disable

namespace ToTaxi
{
    public partial class User
    {
        public User()
        {
            RoulPps = new HashSet<RoulPp>();
            Zakazs = new HashSet<Zakaz>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Fam { get; set; }
        public string Otc { get; set; }
        public DateTime? DateBird0 { get; set; }
        public int? Pol { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string LogininVx { get; set; }
        public string PasswordInVx { get; set; }
        public int? Roul { get; set; }
        public int? FuncPp { get; set; }
        public byte[] Photo { get; set; }

        public virtual FuncPp FuncPpNavigation { get; set; }
        public virtual PolPol PolNavigation { get; set; }
        public virtual ICollection<RoulPp> RoulPps { get; set; }
        public virtual ICollection<Zakaz> Zakazs { get; set; }
    }
}
