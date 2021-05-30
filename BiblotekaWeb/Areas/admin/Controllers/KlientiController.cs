using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Data;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class KlientiController : Controller
    {
        private readonly IKlientiService _klientiService;
        private readonly INotyfService _notyf;

        public KlientiController(IKlientiService klientiService,INotyfService notyf)
        {
            _klientiService = klientiService;
            _notyf = notyf;
        }

        public IActionResult Index() => View(_klientiService.GetAllKlients());

        [HttpGet]
        public IActionResult Shto() => View();


        [HttpPost]
        public IActionResult Shto(Klienti klienti)
        {
            if (!ModelState.IsValid) return View(klienti);
            _klientiService.ShtoKlient(klienti);
            _notyf.Custom("Klienti u shtua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edito(string id)
        {       
            if (id == null)
            {
                return NotFound();
            }
            var klienti = _klientiService.GetKlientById(id);
            return View(klienti);
        }

        [HttpPost]
        public IActionResult Edito(Klienti klienti)
        {
            if (!ModelState.IsValid) return View(klienti);
            _klientiService.PerditesoKlient(klienti);
            _notyf.Custom("Klienti u përditësua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _klientiService.DeleteKlient(id);
            _notyf.Custom("Klienti u fshi!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }
    }
}
