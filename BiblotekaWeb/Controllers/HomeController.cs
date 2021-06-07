using BiblotekaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BiblotekaWeb.Areas.admin.Models;
using BiblotekaWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BiblotekaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BiblotekaWebContext _context;

        public HomeController(ILogger<HomeController> logger,BiblotekaWebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Librat = _context.Libris.Include(x => x.Gjuha).Skip(1).Take(5).ToList(),
                Kategorite = _context.Kategoria.Take(4).ToList(),
                Stafi = _context.Stafis.Include(x=>x.Perdoruesis).ThenInclude(r=>r.Roli).ToList()
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
