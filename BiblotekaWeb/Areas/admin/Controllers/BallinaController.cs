using System.Linq;
using BiblotekaWeb.Areas.admin.Models;
using BiblotekaWeb.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class BallinaController : Controller
    {
        private readonly BiblotekaWebContext _context;

        public BallinaController(BiblotekaWebContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var klientet = _context.Klientis.OrderByDescending(x => x.InsertDate).Take(5).ToList();
            var aktivitet = _context.Aktivitetis.OrderByDescending(x => x.AktivitetiId).Include(x => x.Klienti)
                .Include(x => x.Libri).Take(5).ToList();
            var model = new BallinaViewModel()
            {
                Klientet = klientet,
                Aktivitetet = aktivitet
            };
            ViewBag.Klientet = _context.Klientis.Count();
            ViewBag.Librat = _context.Libris.Count();
            ViewBag.Huazimet = _context.Huazimis.Count();
            ViewBag.Kthimet = _context.Huazimis.Count(x => !x.Statusi);
            return View(model);
        }
    }
}
