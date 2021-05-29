using System.Collections.Generic;
using System.Linq;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class LibriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Shto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Shto(Libri libri)
        {
            var librat = new List<Libri>();
            if (ModelState.IsValid)
            {
                librat.Add(libri);
            }
            return View();
        }


        [HttpGet]
        public IActionResult Detalet(string id)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edito(int id)
        {
            return View();
        }
    }
}
