using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblotekaWeb.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Index()
        {
            var stafi = _context.Stafis.ToList();
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
                var stafid = Convert.ToInt32(User.FindFirst(x => x.Type == "Id")?.Value);

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            model.Stafi.InsertBy = stafid;
                            model.Stafi.InsertDate = DateTime.Now;
                            await _context.Stafis.AddAsync(model.Stafi);
                            await _context.SaveChangesAsync();
                            _notyf.Custom("Stafi u shtua!", 5, "#FFBC53", "fa fa-check");
                            return RedirectToAction(nameof(Index));
                        }
                        return View(model);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                }
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
