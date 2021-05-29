using System;
using System.Collections.Generic;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Perdoruesi
    {
        public int PerdoruesiId { get; set; }
        public int StafiId { get; set; }
        public int RoliId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid? ResetPasswordCode { get; set; }
        public string IsActive { get; set; }

        public virtual Roli Roli { get; set; }
        public virtual Stafi Stafi { get; set; }
    }
}
