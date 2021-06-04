using System;
using System.Linq;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class KthimetController : Controller
    {
        private readonly BiblotekaWebContext _context;

        public KthimetController(BiblotekaWebContext context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Print()
        {
            const string footer = "--footer-center \"Copyright © 2021 Library Management System.  Page: [page]/[toPage]\"" + " --footer-line --footer-font-size \"10\" --footer-font-name \"Poppins light\"";
            var stafiId = Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value);
            var stafi = _context.Stafis.Single(x => x.StafiId == stafiId);
            ViewData["Stafi"] = stafi.Emri + " " + stafi.Mbiemri;
            var kthimet = _context.Huazimis.Include(x => x.Klienti).Include(x => x.Libri)
                .Where(x => !x.Statusi).ToList();
            return new ViewAsPdf(kthimet, ViewData)
            {
                CustomSwitches = footer
            };
        }
    }
}