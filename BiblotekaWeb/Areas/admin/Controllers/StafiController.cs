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
using Microsoft.Data.SqlClient;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class StafiController : Controller
    {
        private readonly BiblotekaWebContext _context;
        private readonly INotyfService _notyf;
        private IConfiguration Config { get; }


        public StafiController(BiblotekaWebContext context,INotyfService notyf,IConfiguration config)
        {
            _context = context;
            this._notyf = notyf;
            Config = config;
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
                var perdoruesi = _context.Perdoruesis.FirstOrDefault(x => x.PerdoruesiId == model.Perdoruesi.PerdoruesiId);

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        model.Stafi.InsertBy = stafid;
                        model.Stafi.InsertDate = DateTime.Now;
                        model.Perdoruesi.IsActive = 1.ToString();
                        model.Perdoruesi.StafiId =Convert.ToInt32(id);
                        _context.Stafis.AddAsync(model.Stafi);
                        _context.SaveChangesAsync();
                        _context.Perdoruesis.AddAsync(model.Perdoruesi);
                        _context.SaveChangesAsync();
                        transaction.Commit();
                        _notyf.Custom("Stafi u shtua!", 5, "#FFBC53", "fa fa-check");
                        
                                               
                    }
                    catch (Exception)
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
            if (stafi != null)
            {
                _context.Stafis.Remove(stafi);
                _context.SaveChanges();
                _notyf.Custom("Stafi u fshi me sukses!", 5, "#FFBC53", "fa fa-check");
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalet()
        {
            var user = _context.Stafis.FirstOrDefault(x => x.StafiId == id);
            return View(user);
        }

    }
}
