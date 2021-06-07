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

        public string Emri { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Mbiemri { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [DataType(DataType.Date)]
        public DateTime Datalindjes { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selektoni Gjininë")]
        public string Gjinia { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [MinLength(10,ErrorMessage = "Numri personal duhet të ketë 10 numra")]
        [MaxLength(10,ErrorMessage = "Numri personal duhet të ketë 10 numra")]
        public string NrPersonal { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string NrKontaktues { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Adresa { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Qyteti { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Shteti { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string KodiPostal { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [EmailAddress]
        public string Emaili { get; init; }
        public int? Huazimet { get; set; }
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
