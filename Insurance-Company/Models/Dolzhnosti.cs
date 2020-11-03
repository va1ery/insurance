using System;
using System.Collections.Generic;

namespace Insurance_Company.Models
{
    public partial class Dolzhnosti
    {
        public Dolzhnosti()
        {
            Sotrudniki = new HashSet<Sotrudniki>();
        }

        public long KodDolzhnosti { get; set; }
        public string NaimenovanieDolzhnosti { get; set; }
        public double Oklad { get; set; }
        public string Obyazannosti { get; set; }
        public string Trebovaniya { get; set; }

        public virtual ICollection<Sotrudniki> Sotrudniki { get; set; }
    }
}
