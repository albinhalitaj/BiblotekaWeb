using System.Collections.Generic;
using BiblotekaWeb.Areas.admin.Models;

namespace BiblotekaWeb.ViewModels
{
    public class LibrariaViewModel
    {
        public List<Libri> Librat { get; init; }
        public List<Kategorium> Kategorite { get; init; }
        public string SearchString { get; set; }
    }
}