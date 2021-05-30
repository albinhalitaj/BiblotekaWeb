using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Data;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class LibriController : Controller
    {
        private readonly ILibriService _libriService;
        private readonly INotyfService _notyfi;
        private readonly BiblotekaWebContext _webContext;

        public LibriController(ILibriService libriService, INotyfService notyf,BiblotekaWebContext webContext)
        {
            _libriService = libriService;
            _notyfi = notyf;
            _webContext = webContext;
        }

        public IActionResult Index() 
        {
            ViewBag.Kategorite = _webContext.Kategoria.ToList();
             return View(_libriService.GetAllLibri()); 
           
        }
        
        
       
        [HttpGet]
        public IActionResult Shto() => View();


        [HttpPost]
        public IActionResult Shto(Libri libri)
        {
            if (!ModelState.IsValid) return View(libri);
            _libriService.ShtoLibrin(libri);
            _notyfi.Custom("Libri u shtua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edito(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var libri = _libriService.GetLibriById(id);
            return View(libri);
        }

        [HttpPost]
        public IActionResult Edito(Libri libri)
        {
            if (!ModelState.IsValid) return View(libri);
            _libriService.PerditesoLibrin(libri);
            _notyfi.Custom("Klienti u përditësua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _libriService.DeleteLibrin(id);
            _notyfi.Custom("Libri u fshi!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }
    }
}
