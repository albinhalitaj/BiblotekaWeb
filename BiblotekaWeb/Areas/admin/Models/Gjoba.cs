using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Gjoba
    {
        public int GjobaId { get; set; }
       
        public string KlientiId { get; init; }
        public string LibriId { get; init; }
        public DateTime Data { get; init; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public decimal Shuma { get; init; }
        public decimal ShumaPranuar { get; init; }
        public int? InsertBy { get; init; }
        public DateTime? InsertDate { get; init; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual Klienti Klienti { get; set; }
        public virtual Libri Libri { get; set; }
    }
}
