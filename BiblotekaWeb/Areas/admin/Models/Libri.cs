using System;
using System.Collections.Generic;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Libri
    {
        public Libri()
        {
            Aktivitetis = new HashSet<Aktiviteti>();
            Gjobas = new HashSet<Gjoba>();
            Huazimis = new HashSet<Huazimi>();
        }

        public string LibriId { get; set; }
        public string Titulli { get; set; }
        public string Autori { get; set; }
        public string Botuesi { get; set; }
        public int GjuhaId { get; set; }
        public int KategoriaId { get; set; }
        public string Isbn { get; set; }
        public string Editioni { get; set; }
        public int NumriKopjeve { get; set; }
        public bool Statusi { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual Gjuha Gjuha { get; set; }
        public virtual Kategorium Kategoria { get; set; }
        public virtual ICollection<Aktiviteti> Aktivitetis { get; set; }
        public virtual ICollection<Gjoba> Gjobas { get; set; }
        public virtual ICollection<Huazimi> Huazimis { get; set; }
    }
}
