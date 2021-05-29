using System;
using System.Collections.Generic;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Klienti
    {
        public Klienti()
        {
            Aktivitetis = new HashSet<Aktiviteti>();
            Gjobas = new HashSet<Gjoba>();
            Huazimis = new HashSet<Huazimi>();
        }

        public string KlientiId { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public DateTime Datalindjes { get; set; }
        public string Gjinia { get; set; }
        public string NrPersonal { get; set; }
        public string NrKontaktues { get; set; }
        public string Adresa { get; set; }
        public string Qyteti { get; set; }
        public string Shteti { get; set; }
        public string KodiPostal { get; set; }
        public string Emaili { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual ICollection<Aktiviteti> Aktivitetis { get; set; }
        public virtual ICollection<Gjoba> Gjobas { get; set; }
        public virtual ICollection<Huazimi> Huazimis { get; set; }
    }
}
