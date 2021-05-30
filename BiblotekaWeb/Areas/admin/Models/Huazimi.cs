using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Huazimi
    {
        public int HuazimiId { get; set; }
        public int StafiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selekto Librin")]
        
        public string LibriId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selektoni Klientin")]
    
        public string KlientiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public int NumriKopjeve { get; set; }
        
        public DateTime DataHuazimi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selekto daten e kthimit")]
        [DataType(DataType.Date)]
        public DateTime DataKthimit { get; set; }
        public bool Statusi { get; set; }
      
        public string Pershkrimi { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual Klienti Klienti { get; set; }
        public virtual Libri Libri { get; set; }
        public virtual Stafi Stafi { get; set; }
    }
}
