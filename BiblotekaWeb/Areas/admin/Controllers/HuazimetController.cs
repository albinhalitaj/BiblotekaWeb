using System;
using System.Collections.Generic;
using System.Linq;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class HuazimetController : Controller
    {
        private readonly BiblotekaWebContext _context;

        public HuazimetController(BiblotekaWebContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Huazo()
        {
            ViewBag.Librat = _context.Libris.Where(x => x.NumriKopjeve > 0).ToList();
            var list = _context.Klientis.Select(s => new SelectListItem
            {
                Value = s.KlientiId,
                Text = string.Concat(s.Emri, " ", s.Mbiemri)
            }).ToList();
            ViewBag.Klientet = new SelectList(list, "Value", "Text");
            return View();
        }


        [HttpPost]
        public IActionResult Huazo(Huazimi model)
        {
            return View();
        }
    }
}
