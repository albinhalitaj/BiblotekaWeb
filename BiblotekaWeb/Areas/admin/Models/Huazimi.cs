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
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem selektoni librin")]
        public string LibriId { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem selektoni klientin")]
        public string KlientiId { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public int NumriKopjeve { get; init; }
        public DateTime DataHuazimi { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selekto datën e kthimit")]
        [DataType(DataType.Date)]
        public DateTime DataKthimit { get; init; }
        public bool Statusi { get; set; }
      
        public string Pershkrimi { get; init; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual Klienti Klienti { get; set; }
        public virtual Libri Libri { get; set; }
    }
}
