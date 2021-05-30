using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Roli
    {
        public Roli()
        {
            Perdoruesis = new HashSet<Perdoruesi>();
        }

       
        public int RoliId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Emrin")]
        [DataType(DataType.Text)]
        public string EmriRolit { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Pershkrimin")]
        [DataType(DataType.Text)]
        public string Pershkrimi { get; set; }

        public virtual ICollection<Perdoruesi> Perdoruesis { get; set; }
    }
}
