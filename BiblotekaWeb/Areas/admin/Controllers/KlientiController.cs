using System;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Data;
using BiblotekaWeb.Areas.admin.Models;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class KlientiController : Controller
    {
        private IConfiguration Configuration { get; }
        private readonly IKlientiService _klientiService;
        private readonly INotyfService _notyf;
        public KlientiController(IKlientiService klientiService,INotyfService notyf,IConfiguration configuration)
        {
            
            Configuration = configuration;
            _klientiService = klientiService;
            _notyf = notyf;
        }

        public IActionResult Index() => View(_klientiService.GetAllKlients());

        [HttpGet]
        public IActionResult Shto() => View();


        [HttpPost]
        public IActionResult Shto(Klienti klienti)
        {
            var klientiId = string.Empty;
            using (var con = new SqlConnection(Configuration.GetConnectionString("Conn")))
                klientiId = con.Query<string>("select dbo.KlientiID()").FirstOrDefault();
            if (!ModelState.IsValid) return View(klienti);
            klienti.KlientiId = klientiId;
            klienti.InsertBy = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            klienti.InsertDate = DateTime.Now;
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
        public IActionResult Edito(string id, Klienti klienti)
        {
            if (!ModelState.IsValid) return View(klienti);
            var klient = _klientiService.GetKlientById(id);
            if (klient.Lun == null)
                klienti.Lun = 1;
            else
                klient.Lun++;
            klienti.Lub = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            klienti.Lud = DateTime.Now;
            klienti.KlientiId = id;
            klienti.InsertBy = klient.InsertBy;
            klienti.InsertDate = klient.InsertDate;
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
            var status = _klientiService.DeleteKlient(id);
            return Json(status);
        }
    }
}
