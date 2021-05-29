﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Kategorium
    {
        public Kategorium()
        {
            Libris = new HashSet<Libri>();
        }

        public int KategoriaId { get; set; }
        public string Emertimi { get; set; }
        public string Pershkrimi { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public int? Lun { get; set; }
        public DateTime? Lud { get; set; }

        public virtual ICollection<Libri> Libris { get; set; }
    }
}
