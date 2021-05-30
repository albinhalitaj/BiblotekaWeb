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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Emrin")]
        [DataType(DataType.Text)]
        public string Emri { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Mbiemrin")]
        [DataType(DataType.Text)]
        public string Mbiemri { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Datelindjen")]
        [DataType(DataType.Date)]
        public DateTime Datalindjes { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Gjinen")]
        public string Gjinia { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani NrPersonal")]
        public string NrPersonal { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani NrKontaktues")]
        [Phone]
        public string NrKontaktues { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Adresen")]
        [DataType(DataType.Text)]
        public string Adresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Qytetit")]
        [DataType(DataType.Text)]
        public string Qyteti { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Shtetin")]
        [DataType(DataType.Text)]
        public string Shteti { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani KodinPostal")]
        [DataType(DataType.PostalCode)]
        public string KodiPostal { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Emailin")]
        [EmailAddress]
        public string Emaili { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual ICollection<Aktiviteti> Aktivitetis { get; set; }
        public virtual ICollection<Gjoba> Gjobas { get; set; }
        public virtual ICollection<Huazimi> Huazimis { get; set; }
    }
}
