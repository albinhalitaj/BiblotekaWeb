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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]

        public string Emri { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]

        public string Mbiemri { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [EmailAddress]
        public string Emaili { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [DataType(DataType.Date)]
        public DateTime Datalindjes { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]

        public string Adresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selektoni Gjinen")]
        public string Gjinia { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
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
