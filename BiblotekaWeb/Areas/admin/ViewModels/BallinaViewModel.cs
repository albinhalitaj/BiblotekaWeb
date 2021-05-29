using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblotekaWeb.Areas.admin.Models;

namespace BiblotekaWeb.Areas.admin.ViewModels
{
    public class BallinaViewModel
    {
        public IEnumerable<Klienti> Klientet { get; set; }
        public IEnumerable<Aktiviteti> Aktivitetet { get; set; }
    }
}
