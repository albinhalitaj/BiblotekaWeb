using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiblotekaWeb.Areas.admin.ViewModels;
using ClosedXML.Excel;
using FluentEmail.Core;
using Rotativa.AspNetCore;


namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class HuazimetController : Controller
    {
        private readonly BiblotekaWebContext _context;
        private readonly INotyfService _notyf;
        private readonly IFluentEmail _email;

        public HuazimetController(BiblotekaWebContext context, INotyfService notyf,[FromServices] IFluentEmail email)
        {
            _context = context;
            _notyf = notyf;
            _email = email;
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
                    catch (Exception)
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
        public IActionResult Kthe(int? id)
        {
            var huazimi = _context.Huazimis.FirstOrDefault(x => x.HuazimiId == id && x.Statusi);
            if (huazimi != null)
            {
                ViewBag.NoOfDays = (DateTime.Now - huazimi.DataKthimit).Days;
                var model = _context.Huazimis.Include(x => x.Klienti)
                    .Include(x => x.Libri).FirstOrDefault(x => x.HuazimiId == huazimi.HuazimiId && x.Statusi);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kthe(int? id,decimal shuma)
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
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Njofto(int? id)
        {
            var huazimi = _context.Huazimis.Include(x => x.Klienti)
                .Include(x => x.Libri).FirstOrDefault(x => x.HuazimiId == id);
            var model = new HuazimiMesazhiViewModel
            {
                Huazimi = huazimi,
                Mesazhi = new Mesazhi()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Njofto(int id,HuazimiMesazhiViewModel model)
        {
            var klienti = (from s in _context.Huazimis
                where s.HuazimiId == id
                select s.Klienti).FirstOrDefault();
            if (klienti != null)
                await SendEmailToClient(string.Concat(klienti.Emri, " ", klienti.Mbiemri), klienti.Emaili,
                    model.Mesazhi.Përmbajtja, model.Mesazhi.Subjekti);
            _notyf.Custom("Emaili është dërguar me sukses!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        public async Task SendEmailToClient(string fullName,string emaili,string mesazhi,string subjekti)
        {
            var email = _email.To(emaili, fullName)
                .Subject(subjekti)
                .Body(mesazhi, isHtml: true);
            await email.SendAsync();
        }

        public IActionResult Print()
        {
            const string footer = "--footer-center \"Copyright © 2021 Library Management System.  Page: [page]/[toPage]\"" + " --footer-line --footer-font-size \"10\" --footer-font-name \"Poppins light\"";
            var stafiId = Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value);
            var stafi = _context.Stafis.Single(x => x.StafiId == stafiId);
            ViewData["Stafi"] = stafi.Emri + " " + stafi.Mbiemri;
            var huazimet = _context.Huazimis.Include(x => x.Klienti).Include(x => x.Libri)
                .Where(x=>x.Statusi).ToList();
            return new ViewAsPdf(huazimet, ViewData)
            {
                CustomSwitches = footer
            };
        }

        public IActionResult Export() => Excel();

        public IActionResult Excel()
        {
            var huazimet = _context.Huazimis.Include(x => x.Klienti).Include(x => x.Libri)
                .Where(x => x.Statusi).ToList();
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Huazimet");
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = "HuazimiID";
            worksheet.Cell(currentRow, 2).Value = "Klienti";
            worksheet.Cell(currentRow, 3).Value = "Libri";
            worksheet.Cell(currentRow, 4).Value = "Data Huazimit";
            worksheet.Cell(currentRow, 5).Value = "Data Kthimit";
            worksheet.Cell(currentRow, 6).Value = "Sasia";

            IXLRange range = worksheet.Range(worksheet.Cell(currentRow, 1).Address,
                worksheet.Cell(currentRow, 6).Address);
            range.Style.Font.Bold = true;
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            worksheet.ColumnWidth = 20;
            foreach (var huazim in huazimet)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = huazim.HuazimiId;
                worksheet.Cell(currentRow, 2).Value = string.Concat(huazim.Klienti.Emri, " ", huazim.Klienti.Mbiemri);
                worksheet.Cell(currentRow, 3).Value = huazim.Libri.Titulli;
                worksheet.Cell(currentRow, 4).Value = huazim.DataHuazimi.ToString("d");
                worksheet.Cell(currentRow, 5).Value = huazim.DataKthimit.ToString("d");
                worksheet.Cell(currentRow, 6).Value = huazim.NumriKopjeve;
            }
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Huazimet.xlsx");
        }
    }
}
