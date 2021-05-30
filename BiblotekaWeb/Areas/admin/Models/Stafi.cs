using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Stafi
    {
        public Stafi()
        {
            Aktivitetis = new HashSet<Aktiviteti>();
            Huazimis = new HashSet<Huazimi>();
            Perdoruesis = new HashSet<Perdoruesi>();
        }
       
        public int StafiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Emrin")]
        [DataType(DataType.Text)]
        public string Emri { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Mbiemrin")]
        [DataType(DataType.Text)]
        public string Mbiemri { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Emailin")]
        [EmailAddress]
        public string Emaili { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Datelindjen")]
        [DataType(DataType.Date)]
        public DateTime Datalindjes { get; set; }
        [Required(ErrorMessage = "Ju lutem shkruani Adresen")]
        [DataType(DataType.Text)]
        public string Adresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Gjinen")]
        public string Gjinia { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani NrTelefonit")]
        [Phone]
        public string Telefoni { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual ICollection<Aktiviteti> Aktivitetis { get; set; }
        public virtual ICollection<Huazimi> Huazimis { get; set; }
        public virtual ICollection<Perdoruesi> Perdoruesis { get; set; }
    }
}
