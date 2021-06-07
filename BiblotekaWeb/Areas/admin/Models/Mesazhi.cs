using System.ComponentModel.DataAnnotations;

namespace BiblotekaWeb.Areas.admin.Models
{
    public class Mesazhi
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Subjekti { get; init; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "Kjo fushë është e obligueshme")]
        [MinLength(10,ErrorMessage = "Mesazhi duhet të jetë më shumë se 10 karaktere")]
        public string Përmbajtja { get; init; }
    }
}