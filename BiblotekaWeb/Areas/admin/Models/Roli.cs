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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]

        public string EmriRolit { get; set; }
        
        public string Pershkrimi { get; set; }

        public virtual ICollection<Perdoruesi> Perdoruesis { get; set; }
    }
}
