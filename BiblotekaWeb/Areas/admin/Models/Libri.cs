using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Titullin")]
        [DataType(DataType.Text)]
        public string Titulli { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Autorin")]
        [DataType(DataType.Text)]
        public string Autori { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Botuesin")]
        [DataType(DataType.Text)]
        public string Botuesi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Gjuhen")]
        [DataType(DataType.Text)]
        public int GjuhaId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Kategorin")]
        [DataType(DataType.Text)]
        public int KategoriaId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani ISBN")]
        public string Isbn { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Edicionin")]
        [DataType(DataType.Text)]
        public string Editioni { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Numrin e Kopjev")]
        [DataType(DataType.Text)]
        public int NumriKopjeve { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Statusin")]
        [DataType(DataType.Text)]
        public bool Statusi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem insertoni nje foto")]
        [NotMapped]
        public string ImageName { get; set; }
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
