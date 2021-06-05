using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiblotekaWeb.Areas.admin.Data;
using BiblotekaWeb.Areas.admin.ViewModels;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class StafiController : Controller
    {
        private readonly BiblotekaWebContext _context;
        private readonly INotyfService _notyf;


        public StafiController(BiblotekaWebContext context,INotyfService notyf)
        {
            _context = context;
            this._notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            var stafi = await _context.Stafis.ToListAsync();
            return View(stafi);
        }
        [HttpGet]
        public IActionResult Shto()
        {
            ViewBag.Rolet = _context.Rolis.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Shto(StafPerdoruesitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var stafid = Convert.ToInt32(User.FindFirst(x => x.Type == "Id")?.Value);
                var roliId = Convert.ToInt32(User.FindFirst(x => x.Type == "Id")?.Value);

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {

                        model.Stafi.InsertBy = stafid;
                        model.Perdoruesi.RoliId = roliId;
                        model.Stafi.InsertDate = DateTime.Now;
                        await _context.Stafis.AddAsync(model.Stafi);
                        await _context.SaveChangesAsync();
                        _notyf.Custom("Stafi u shtua!", 5, "#FFBC53", "fa fa-check");
                        return RedirectToAction(nameof(Index));

                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
            return View(model);
        }



        public IActionResult Fshi(int id)
        {
            var stafi = _context.Stafis.FirstOrDefault(x => x.StafiId == id);
            if (stafi != null)
            {
                _context.Stafis.Remove(stafi);
                _context.SaveChanges();
                _notyf.Custom("Stafi u fshi me sukses!", 5, "#FFBC53", "fa fa-check");
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
