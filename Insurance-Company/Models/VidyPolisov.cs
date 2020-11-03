using System;
using System.Collections.Generic;

namespace Insurance_Company.Models
{
    public partial class VidyPolisov
    {
        public VidyPolisov()
        {
            Polisy = new HashSet<Polisy>();
        }

        public long KodVidaPolisa { get; set; }
        public string Naimenovanie { get; set; }
        public string Opisanie { get; set; }
        public string Usloviya { get; set; }
        public long KodRiska { get; set; }

        public virtual Riski KodRiskaNavigation { get; set; }
        public virtual ICollection<Polisy> Polisy { get; set; }
    }
}
