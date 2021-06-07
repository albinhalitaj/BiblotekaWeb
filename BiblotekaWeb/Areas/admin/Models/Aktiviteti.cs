using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Aktiviteti
    {
        public int AktivitetiId { get; set; }
       
        public int PunetoriId { get; init; }
       
        public string KlientiId { get; init; }
       
        public string LibriId { get; init; }
       
        public Tipet Tipi { get; init; }
       
        public DateTime Data { get; init; }
       
        public virtual Klienti Klienti { get; set; }
        public virtual Libri Libri { get; set; }
        public virtual Stafi Punetori { get; set; }
    }
}
