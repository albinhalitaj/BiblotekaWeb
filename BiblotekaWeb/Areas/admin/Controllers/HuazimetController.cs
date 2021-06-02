using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiblotekaWeb.Areas.admin.Data;


namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class HuazimetController : Controller
    {
        private readonly BiblotekaWebContext _context;
        private readonly INotyfService _notyf;
        private readonly IHuazoService _huazoService;

        public HuazimetController(BiblotekaWebContext context, INotyfService _notyf)
        {
            _context = context;
            this._notyf = _notyf;
        }
        
        public IActionResult Index()
        {
            var huazo = _huazoService.GetAllHuazimet();
            return View(huazo);
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
            if (ModelState.IsValid)
            {
                var libri = _context.Libris.FirstOrDefault(x => x.LibriId == model.LibriId);
                var stafiId = Convert.ToInt32(User.FindFirst(x => x.Type == "Id")?.Value);
                var klienti = _context.Klientis.FirstOrDefault(x => x.KlientiId == model.KlientiId);
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        if (klienti.Huazimet == null)
                            klienti.Huazimet = 1;
                        else
                            klienti.Huazimet++;
                        model.Statusi = true;
                        model.StafiId = stafiId;
                        model.InsertBy = stafiId; 
                        model.InsertDate = DateTime.Now;
                        libri.NumriKopjeve -= model.NumriKopjeve;
                        if (libri.NumriKopjeve <= 0) libri.Statusi = false;
                        var act = new Aktiviteti
                        {
                            KlientiId = model.KlientiId,
                            LibriId = model.LibriId,
                            Data = DateTime.Now,
                            PunetoriId = stafiId,
                            Tipi = Tipet.Huazim
                        };
                        _context.Entry(libri).State = EntityState.Modified;
                        _context.Entry(klienti).State = EntityState.Modified;
                        _context.Aktivitetis.Add(act);
                        _context.SaveChanges();
                        _context.Huazimis.Add(model);
                        _context.SaveChanges();
                        
                        transaction.Commit();
                        _notyf.Custom("Libri u huazua me sukses!", 5, "#FFBC53", "fa fa-check");
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        _notyf.Error("Ndodhi një gabim! Ju lutemi provoni përsëri.",5);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var status = _huazoService.DeleteHuazimin(id);
            return Json(status);
        }
    }
}
