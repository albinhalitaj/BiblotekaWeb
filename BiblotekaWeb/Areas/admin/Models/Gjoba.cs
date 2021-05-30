using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Gjoba
    {
        public int GjobaId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni ID e klientit")]
        [DataType(DataType.Text)]
        public string KlientiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni ID e librit")]
        [DataType(DataType.Text)]
        public string LibriId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni daten e gjobes")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni shume e gjobes")]
        [DataType(DataType.Currency)]
        public decimal Shuma { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni e pranuar te gjobes")]
        [DataType(DataType.Currency)]
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
