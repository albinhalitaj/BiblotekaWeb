using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Libri
    {
        public Libri()
        {
            Aktivitetis = new HashSet<Aktiviteti>();
            Gjobas = new HashSet<Gjoba>();
            Huazimis = new HashSet<Huazimi>();
        }

       
        public string LibriId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Titulli { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Autori { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Botuesi { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selektoni Gjuhën")]
        public int GjuhaId { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Selektoni Kategorinë")]
        public int KategoriaId { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Isbn { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Editioni { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public int NumriKopjeve { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public bool Statusi { get; set; }
        public string ImageName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [NotMapped]
        public IFormFile Image { get; init; }
        public int InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual Gjuha Gjuha { get; set; }
        public virtual Kategorium Kategoria { get; set; }
        public virtual ICollection<Aktiviteti> Aktivitetis { get; set; }
        public virtual ICollection<Gjoba> Gjobas { get; set; }
        public virtual ICollection<Huazimi> Huazimis { get; set; }
    }
}
