using System;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiblotekaWeb.Areas.admin.ViewModels;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    public class StafiController : Controller
    {
        private readonly BiblotekaWebContext _context;
        private readonly INotyfService _notyf;
        private IConfiguration Config { get; }


        public StafiController(BiblotekaWebContext context,INotyfService notyf,IConfiguration config)
        {
            _context = context;
            _notyf = notyf;
            Config = config;
        }
        
        public IActionResult Index()
        {
            var model = _context.Stafis.ToList();
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Shto()
        {
            ViewBag.Rolet = _context.Rolis.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Shto(StafPerdoruesitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var id = string.Empty;
                using (var con = new SqlConnection(Config.GetConnectionString("Conn")))
                {
                    id = con.Query<string>("SELECT IDENT_CURRENT('Stafi') + 1").FirstOrDefault();
                }
                var stafid = Convert.ToInt32(User.FindFirst(x => x.Type == "Id")?.Value);
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        model.Stafi.InsertBy = stafid;
                        model.Stafi.InsertDate = DateTime.Now;
                        model.Perdoruesi.IsActive = 1.ToString();
                        model.Perdoruesi.StafiId =Convert.ToInt32(id);
                        _context.Stafis.Add(model.Stafi);
                        _context.SaveChanges();
                        _context.Perdoruesis.Add(model.Perdoruesi);
                        _context.SaveChanges();
                        transaction.Commit();
                        _notyf.Custom("Stafi u shtua!", 5, "#FFBC53", "fa fa-check");
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        _notyf.Error("Ndodhi një gabim! Ju lutemi provoni përsëri.", 5);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        public IActionResult Fshi(int id)
        {
            var stafi = _context.Stafis.FirstOrDefault(x => x.StafiId == id);
            var perdoruesi = _context.Perdoruesis.FirstOrDefault(x => x.StafiId == stafi.StafiId);
            if (stafi == null) return RedirectToAction(nameof(Index));
            _context.Perdoruesis.Remove(perdoruesi);
            _context.Stafis.Remove(stafi);
            _context.SaveChanges();
            _notyf.Custom("Stafi u fshi me sukses!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction("Index", "Stafi");
        }
        
        
        public IActionResult Detalet(int id)
        {
            var staf = _context.Stafis.FirstOrDefault(s => s.StafiId == id);
            var perdoruesi = _context.Perdoruesis.Include(r => r.Roli).FirstOrDefault(p => p.StafiId == id);
            ViewBag.Roli = perdoruesi.Roli.EmriRolit;    
            return View(staf);
        }
        
        
        [HttpGet]
        public IActionResult Edito(int id)
        {
            var stafi = _context.Stafis.FirstOrDefault(x => x.StafiId == id);
            var perdoruesi = _context.Perdoruesis.FirstOrDefault(x => x.StafiId == stafi.StafiId);
            var model = new StafPerdoruesitViewModel
            {
                Stafi = stafi,
                Perdoruesi = perdoruesi
            };
            ViewBag.Rolet = _context.Rolis.ToList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Edito(StafPerdoruesitViewModel model,int id)
        {
            if (!ModelState.IsValid) return View(model);
            var staf = _context.Stafis.FirstOrDefault(x => x.StafiId == id);
            var perdoruesi = _context.Perdoruesis.FirstOrDefault(x => x.StafiId == staf.StafiId);
            if (staf.Lun == null)
                staf.Lun = 1;
            else
                staf.Lun++;
            staf.Lud = DateTime.Now;
            staf.Lub = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            staf.Emri = model.Stafi.Emri;
            staf.Mbiemri = model.Stafi.Mbiemri;
            staf.Adresa = model.Stafi.Adresa;
            staf.Datalindjes = model.Stafi.Datalindjes;
            staf.Telefoni = model.Stafi.Telefoni;
            staf.Emaili = model.Stafi.Emaili;
            staf.Adresa = model.Stafi.Adresa;
            staf.Gjinia = model.Stafi.Gjinia;
            perdoruesi.Username = model.Perdoruesi.Username;
            perdoruesi.Password = model.Perdoruesi.Password;
            perdoruesi.RoliId = model.Perdoruesi.RoliId;
            _context.Stafis.Update(staf);
            _context.Perdoruesis.Update(perdoruesi);
            _context.SaveChanges();
            _notyf.Custom("Stafi u përditësua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }
        
        
    }
}
