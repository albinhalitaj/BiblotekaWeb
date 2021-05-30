using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Gjoba
    {
        public int GjobaId { get; set; }
       
        public string KlientiId { get; set; }
        
        public string LibriId { get; set; }
       
        public DateTime Data { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        
        public decimal Shuma { get; set; }
        
        public decimal ShumaPranuar { get; set; }

        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual Klienti Klienti { get; set; }
        public virtual Libri Libri { get; set; }
    }
}
