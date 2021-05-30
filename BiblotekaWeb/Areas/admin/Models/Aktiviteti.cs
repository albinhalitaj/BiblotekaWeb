using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Aktiviteti
    {
        public int AktivitetiId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Shtypni ID e puntorit")]
        [DataType(DataType.Text)]
        public int PunetoriId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni ID e klientit")]
        [DataType(DataType.Text)]
        public string KlientiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni ID e librit")]
        [DataType(DataType.Text)]
        public string LibriId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni tipin")]
        [DataType(DataType.Text)]
        public string Tipi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shtypni daten ")]
        [DataType(DataType.Text)]

        public DateTime Data { get; set; }
       
        public virtual Klienti Klienti { get; set; }
        public virtual Libri Libri { get; set; }
        public virtual Stafi Punetori { get; set; }
    }
}
