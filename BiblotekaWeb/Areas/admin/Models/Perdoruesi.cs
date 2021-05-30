using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class Perdoruesi
    {
       
        public int PerdoruesiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani ID e Stafit")]
        public int StafiId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani ID e Rolit")]
        public int RoliId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ju lutem shkruani Passwordin")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public Guid? ResetPasswordCode { get; set; }
        public string IsActive { get; set; }

        public virtual Roli Roli { get; set; }
        public virtual Stafi Stafi { get; set; }
    }
}
