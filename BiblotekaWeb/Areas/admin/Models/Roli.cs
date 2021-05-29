using System;
using System.Collections.Generic;

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
        public string EmriRolit { get; set; }
        public string Pershkrimi { get; set; }

        public virtual ICollection<Perdoruesi> Perdoruesis { get; set; }
    }
}
