using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Perdoruesi
    {
       
        public int PerdoruesiId { get; set; }
       
        public int StafiId { get; set; }
       
        public int RoliId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kjo fushë është e obligueshme")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage = "Passwordi duhet të ketë më shumë se 6 karaktere")]
        public string Password { get; set; }
        public Guid? ResetPasswordCode { get; set; }
        public string IsActive { get; set; }

        public virtual Roli Roli { get; set; }
        public virtual Stafi Stafi { get; set; }
    }
}
