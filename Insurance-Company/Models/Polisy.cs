using System;
using System.Collections.Generic;

namespace Insurance_Company.Models
{
    public partial class Polisy
    {
        public long NomerPolisa { get; set; }
        public DateTime DataNachala { get; set; }
        public DateTime DataOkonchaniya { get; set; }
        public double Stoimost { get; set; }
        public double SummaVyplaty { get; set; }
        public string OtmetkaOVyplate { get; set; }
        public string OtmetkaObOkonchanii { get; set; }
        public long KodVidaPolisa { get; set; }
        public long KodKlienta { get; set; }
        public long KodSotrudnika { get; set; }

        public virtual Klienty KodKlientaNavigation { get; set; }
        public virtual Sotrudniki KodSotrudnikaNavigation { get; set; }
        public virtual VidyPolisov KodVidaPolisaNavigation { get; set; }
    }
}
