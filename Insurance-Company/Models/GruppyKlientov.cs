using System;
using System.Collections.Generic;

namespace Insurance_Company.Models
{
    public partial class GruppyKlientov
    {
        public GruppyKlientov()
        {
            Klienty = new HashSet<Klienty>();
        }

        public long KodGruppy { get; set; }
        public string Naimenovanie { get; set; }
        public string Opisanie { get; set; }

        public virtual ICollection<Klienty> Klienty { get; set; }
    }
}
