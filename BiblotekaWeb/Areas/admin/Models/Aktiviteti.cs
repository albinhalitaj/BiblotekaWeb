using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Aktiviteti
    {
        public int AktivitetiId { get; set; }
       
        public int PunetoriId { get; set; }
       
        public string KlientiId { get; set; }
       
        public string LibriId { get; set; }
       
        public string Tipi { get; set; }
       
        public DateTime Data { get; set; }
       
        public virtual Klienti Klienti { get; set; }
        public virtual Libri Libri { get; set; }
        public virtual Stafi Punetori { get; set; }
    }
}
