using System;
using System.Collections.Generic;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Stafi
    {
        public Stafi()
        {
            Aktivitetis = new HashSet<Aktiviteti>();
            Huazimis = new HashSet<Huazimi>();
            Perdoruesis = new HashSet<Perdoruesi>();
        }

        public int StafiId { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Emaili { get; set; }
        public DateTime Datalindjes { get; set; }
        public string Adresa { get; set; }
        public string Gjinia { get; set; }
        public string Telefoni { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual ICollection<Aktiviteti> Aktivitetis { get; set; }
        public virtual ICollection<Huazimi> Huazimis { get; set; }
        public virtual ICollection<Perdoruesi> Perdoruesis { get; set; }
    }
}
