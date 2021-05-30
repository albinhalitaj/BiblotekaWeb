using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Klienti
    {
        public Klienti()
        {
            Aktivitetis = new HashSet<Aktiviteti>();
            Gjobas = new HashSet<Gjoba>();
            Huazimis = new HashSet<Huazimi>();
        }

        public string KlientiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]

        public string Emri { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Mbiemri { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [DataType(DataType.Date)]
        public DateTime Datalindjes { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selektoni Gjinen")]
        public string Gjinia { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string NrPersonal { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [Phone]
        public string NrKontaktues { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Adresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Qyteti { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Shteti { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        
        public string KodiPostal { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [EmailAddress]
        public string Emaili { get; set; }
        public int InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual ICollection<Aktiviteti> Aktivitetis { get; set; }
        public virtual ICollection<Gjoba> Gjobas { get; set; }
        public virtual ICollection<Huazimi> Huazimis { get; set; }
    }
}
