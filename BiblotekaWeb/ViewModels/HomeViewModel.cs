using System.Collections.Generic;
using BiblotekaWeb.Areas.admin.Models;

namespace BiblotekaWeb.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Libri> Librat { get; init; }
        public IEnumerable<Kategorium> Kategorite { get; init; }
        public IEnumerable<Stafi> Stafi { get; init; }
    }
}