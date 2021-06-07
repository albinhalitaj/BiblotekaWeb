using System.Collections.Generic;
using System.Linq;
using BiblotekaWeb.Areas.admin.Models;
using BiblotekaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblotekaWeb.Controllers
{
    public class LibrariaController : Controller
    {
        private readonly BiblotekaWebContext _context;

        public LibrariaController(BiblotekaWebContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            var model = new LibrariaViewModel()
            {
                Librat = _context.Libris.ToList(),
                Kategorite = _context.Kategoria.ToList(),
                SearchString = null
            };
            return View(model);
        }

        public IActionResult Search(string filter, string query)
        {
            ViewBag.TotalLibra = _context.Libris.Count();
            var librat = filter switch
            {
                "Titull" => _context.Libris.Where(x => x.Titulli.Contains(query)).ToList(),
                "Autor" => _context.Libris.Where(x => x.Autori.Contains(query)).ToList(),
                "Botues" => _context.Libris.Where(x => x.Botuesi.Contains(query)).ToList(),
                _ => null
            };
            var model = new LibrariaViewModel()
            {
                Librat = librat,
                Kategorite = _context.Kategoria.ToList(),
                SearchString = query
            };
            return View("Index",model);
        }

        public IActionResult Sort(string kategoria)
        {
            ViewBag.TotalLibra = _context.Libris.Count();
            var librat = _context.Libris.Include(x => x.Kategoria)
                .Where(x => x.Kategoria.Emertimi
                    .Equals(kategoria))
                .ToList();
            var model = new LibrariaViewModel
            {
                Librat = librat,
                Kategorite = _context.Kategoria.ToList(),
                SearchString = kategoria
            };
            return View("Index",model);
        }
    }
}