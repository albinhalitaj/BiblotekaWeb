using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblotekaWeb.Areas.admin.Models;
using BiblotekaWeb.Areas.admin.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class BallinaController : Controller
    {
        private readonly BiblotekaWebContext _context;
        private readonly IConfiguration _config;

        public BallinaController(BiblotekaWebContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        
        public IActionResult Index()
        {
            var klientet = _context.Klientis.OrderByDescending(x => x.InsertDate).Take(5).ToList();
            var aktivitet = _context.Aktivitetis.OrderByDescending(x => x.AktivitetiId).Include(x => x.Klienti)
                .Include(x => x.Libri).Take(5).ToList();
            var model = new BallinaViewModel()
            {
                Klientet = klientet,
                Aktivitetet = aktivitet
            };
            ViewBag.Klientet = _context.Klientis.Count();
            ViewBag.Librat = _context.Libris.Count();
            ViewBag.Huazimet = _context.Huazimis.Count();
            ViewBag.Kthimet = _context.Huazimis.Count(x => !x.Statusi);
            return View(model);
        }


        public async Task<IActionResult> GetData()
        {
            List<ChartViewModel> huazimet = null;
            List<ChartViewModel> kthimet = null;
            await using (var con = new SqlConnection(_config.GetConnectionString("Conn")))
            {
                huazimet = con.Query<ChartViewModel>("EXEC usp_GetHuazimetByMonth").ToList();
                kthimet = con.Query<ChartViewModel>("EXEC [usp_GetKthimetByMonth]").ToList();
            }    
            
            // ADD HUAZIMET TO ARRAY
            var huazimetData = new int[12];
            foreach (var d in huazimet)
                for (var i = 1; i < 12; i++)
                    if ((Convert.ToInt32(d.Muaji) - 1) == i)
                        huazimetData[i] = d.Numri;
            
            
            // ADD KTHIMET TO ARRAY
            var kthimetData = new int[12];
            foreach (var k in kthimet)
                for (var i = 0; i < 12; i++)
                    if ((Convert.ToInt32(k.Muaji) - 1) == i)
                        kthimetData[i] = k.Numri;
            
            return Json(new {huazimetData,kthimetData});
        }
    }
}
