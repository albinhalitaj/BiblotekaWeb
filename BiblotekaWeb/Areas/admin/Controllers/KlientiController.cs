using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Data;
using BiblotekaWeb.Areas.admin.Models;
using ClosedXML.Excel;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Rotativa.AspNetCore;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator,Punëtor")]
    public class KlientiController : Controller
    {
        private IConfiguration Configuration { get; }
        private readonly IKlientiService _klientiService;
        private readonly INotyfService _notyf;
        public KlientiController(IKlientiService klientiService,INotyfService notyf,IConfiguration configuration)
        {
            
            Configuration = configuration;
            _klientiService = klientiService;
            _notyf = notyf;
        }

        public IActionResult Index() => View(_klientiService.GetAllKlients());

        [HttpGet]
        public IActionResult Shto()
        {
            return View();
        }

        public IActionResult GetCities(string country)
        {
            var cities = country switch
            {
                "Kosovë" => BallinaData.GetCities(country),
                "Shqipëri" => BallinaData.GetCities(country),
                "Maqedoni" => BallinaData.GetCities(country),
                "Mali i Zi" => BallinaData.GetCities(country),
                _ => null
            };
            return Json(new {cities});
        }

        [HttpPost]
        public IActionResult Shto(Klienti klienti)
        {
            var klientiId = string.Empty;
            using (var con = new SqlConnection(Configuration.GetConnectionString("Conn")))
                klientiId = con.Query<string>("select dbo.KlientiID()").FirstOrDefault();
            if (!ModelState.IsValid) return View(klienti);
            klienti.KlientiId = klientiId;
            klienti.InsertBy = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            klienti.InsertDate = DateTime.Now;
            _klientiService.ShtoKlient(klienti);
            _notyf.Custom("Klienti u shtua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edito(string id)
        {       
            if (id == null)
            {
                return NotFound();
            }
            var klienti = _klientiService.GetKlientById(id);
            return View(klienti);
        }

        [HttpPost]
        public IActionResult Edito(string id, Klienti klienti)
        {
            if (!ModelState.IsValid) return View(klienti);
            var klient = _klientiService.GetKlientById(id);
            if (klient.Lun == null)
                klienti.Lun = 1;
            else
                klient.Lun++;
            klienti.Lub = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            klienti.Lud = DateTime.Now;
            klienti.KlientiId = id;
            klienti.Huazimet = klient.Huazimet;
            klienti.InsertBy = klient.InsertBy;
            klienti.InsertDate = klient.InsertDate;
            _klientiService.PerditesoKlient(klienti);
            _notyf.Custom("Klienti u përditësua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var status = _klientiService.DeleteKlient(id);
            return Json(status);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Print()
        {
            const string footer = "--footer-center \"Copyright © 2021 Library Management System.  Page: [page]/[toPage]\"" + " --footer-line --footer-font-size \"10\" --footer-font-name \"Poppins light\"";
            var stafiId = Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value);
            var stafi = _klientiService.GetStafi(stafiId);
            ViewData["Stafi"] = stafi.Emri + " " + stafi.Mbiemri;
            return new ViewAsPdf(_klientiService.GetAllKlients(), ViewData)
            {
                CustomSwitches = footer
            };
        }

        public IActionResult Export() => Excel();
        
        public IActionResult Excel()
        {
            var klientet = _klientiService.GetAllKlients();
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Klientët");
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = "KlientiID";
            worksheet.Cell(currentRow, 2).Value = "Emri";
            worksheet.Cell(currentRow, 3).Value = "Mbiemri";
            worksheet.Cell(currentRow, 4).Value = "NumriPersonal";
            worksheet.Cell(currentRow, 5).Value = "Emaili";
            worksheet.Cell(currentRow, 6).Value = "Adresa";
            worksheet.Cell(currentRow, 7).Value = "Huazimet";

            IXLRange range = worksheet.Range(worksheet.Cell(currentRow, 1).Address,
                worksheet.Cell(currentRow, 7).Address);
            range.Style.Font.Bold = true;
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            worksheet.ColumnWidth = 20;
            foreach (var klienti in klientet)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = klienti.KlientiId;
                worksheet.Cell(currentRow, 2).Value = klienti.Emri;
                worksheet.Cell(currentRow, 3).Value = klienti.Mbiemri;
                worksheet.Cell(currentRow, 4).Value = klienti.NrPersonal;
                worksheet.Cell(currentRow, 5).Value = klienti.Emaili;
                worksheet.Cell(currentRow, 6).Value = klienti.Adresa;
                worksheet.Cell(currentRow, 7).Value = klienti.Huazimet;
            }
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Klientët.xlsx");
        }
    }
}
