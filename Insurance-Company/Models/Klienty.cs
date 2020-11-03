using System;
using System.Collections.Generic;

namespace Insurance_Company.Models
{
    public partial class Klienty
    {
        public Klienty()
        {
            Polisy = new HashSet<Polisy>();
        }

        public long KodKlienta { get; set; }
        public string Fio { get; set; }
        public DateTime DataRozhdeniya { get; set; }
        public string Pol { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string PasportnyeDannye { get; set; }
        public long KodGruppy { get; set; }

        public virtual GruppyKlientov KodGruppyNavigation { get; set; }
        public virtual ICollection<Polisy> Polisy { get; set; }
    }
}
