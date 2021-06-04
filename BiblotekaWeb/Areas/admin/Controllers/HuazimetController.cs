using System;
using System.Collections.Generic;
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
    public class HuazimetController : Controller
    {
        private readonly BiblotekaWebContext _context;
        private readonly INotyfService _notyf;

        public HuazimetController(BiblotekaWebContext context, INotyfService _notyf)
        {
            _context = context;
            this._notyf = _notyf;
        }
        
        public async Task<IActionResult> Index()
        {
            var huazimet = await _context.Huazimis.Include(k => k.Klienti)
                .Include(l => l.Libri).ToListAsync(); 
            return View(huazimet);
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

        [HttpGet]
        public async Task<IActionResult> Kthe(int? id)
        {
            var huazimi = await _context.Huazimis.Where(x => x.HuazimiId == id && x.Statusi).FirstOrDefaultAsync();
            ViewBag.NoOfDays = (DateTime.Now - huazimi.DataKthimit).Days;
            var model = _context.Huazimis.Include(x => x.Klienti)
                .Include(x => x.Libri).FirstOrDefault(x => x.HuazimiId == huazimi.HuazimiId && x.Statusi);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Kthe(int? id,decimal shuma)
        {
            if (ModelState.IsValid)
            {
                var huazimi = await _context.Huazimis.FirstOrDefaultAsync(x => x.HuazimiId == id);
                var libri = await _context.Libris.FirstOrDefaultAsync(x => x.LibriId == huazimi.LibriId);
                var ditet = (DateTime.Now - huazimi.DataKthimit).Days;
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (ditet > 0)
                    {
                        var gjoba = new Gjoba
                        {
                            KlientiId = huazimi.KlientiId,
                            LibriId = huazimi.LibriId,
                            Data = DateTime.Now,
                            InsertBy = Convert.ToInt32(User.Claims.First(x=>x.Type == "Id").Value),
                            InsertDate = DateTime.Now,
                            Shuma = shuma,
                            ShumaPranuar = shuma
                        };
                        await _context.AddAsync(gjoba);
                        await _context.SaveChangesAsync();
                    }
                    huazimi.Statusi = false;
                    libri.NumriKopjeve += huazimi.NumriKopjeve;
                    _context.Entry(huazimi).State = EntityState.Modified;
                    _context.Entry(libri).State = EntityState.Modified;
                    var act = new Aktiviteti
                    {
                        KlientiId = huazimi.KlientiId,
                        LibriId = huazimi.LibriId,
                        PunetoriId = Convert.ToInt32(User.Claims.First(x=>x.Type == "Id").Value),
                        Data = DateTime.Now,
                        Tipi = Tipet.Kthim
                    };
                    await _context.AddAsync(act);
                    await _context.SaveChangesAsync();
                    
                   await transaction.CommitAsync();
                   _notyf.Custom("Libri u huazua me sukses!", 5, "#FFBC53", "fa fa-check");
                   
                    
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    _notyf.Error("Ndodhi një gabim! Ju lutemi provoni përsëri.",5);
                }
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Njofto(int? id)
        {
            var huazimi = await _context.Huazimis.Include(x => x.Klienti).Include(x => x.Libri)
                .Where(x => x.HuazimiId == id).FirstOrDefaultAsync();
            var model = new HuazimiMesazhiViewModel
            {
                Huazimi = huazimi,
                Mesazhi = new Mesazhi()
            };
            return View(model);
        }
    }
}
