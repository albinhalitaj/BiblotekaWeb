using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Huazimi
    {
        public int HuazimiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni ID e e stafit")]
        [DataType(DataType.Text)]
        public int StafiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni ID e librit")]
        [DataType(DataType.Text)]
        public string LibriId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni ID e klientit")]
        [DataType(DataType.Text)]
        public string KlientiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni numrin e kopjeve te librit")]
        [DataType(DataType.Text)]
        public int NumriKopjeve { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni daten e huazimit")]
        [DataType(DataType.Date)]
        public DateTime DataHuazimi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni daten e kthimit")]
        [DataType(DataType.Date)]
        public DateTime DataKthimit { get; set; }
        public bool Statusi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni pershkrimin ")]
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
