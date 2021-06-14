using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator,Punëtor")]
    public class KategoriaController : Controller
    {
        private readonly BiblotekaWebContext _context;
        private readonly INotyfService _notyf;

        public KategoriaController(BiblotekaWebContext context,INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var kategorite = await _context.Kategoria.OrderBy(x => x.Emertimi).ToListAsync();
            return View(kategorite);
        }

        [HttpGet]
        public IActionResult Shto() => View();

        [HttpPost]
        public async Task<IActionResult> Shto(Kategorium kategoria)
        {
            if (ModelState.IsValid)
            {
                kategoria.InsertBy = Convert.ToInt32(User.Claims.ElementAt(1).Value);
                kategoria.InsertDate = DateTime.Now;
                await _context.Kategoria.AddAsync(kategoria);
                await _context.SaveChangesAsync();
                _notyf.Custom("Kategoria u shtua!", 5, "#FFBC53", "fa fa-check");
                return RedirectToAction(nameof(Index));
            }
            return View(kategoria);
        }

        [HttpGet]
        public IActionResult Edito(int id)
        {
            var kategoria = _context.Kategoria.FirstOrDefault(x => x.KategoriaId == id);
            if (kategoria == null) 
            {
                return NotFound();
            }
            return View(kategoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edito(int id, Kategorium kategoria)
        {
            if (ModelState.IsValid)
            {
                var kategoriaEdit = _context.Kategoria.FirstOrDefault(x => x.KategoriaId == id);
                if (kategoriaEdit!=null)
                {
                    if (kategoriaEdit.Lun == null)
                        kategoriaEdit.Lun = 1;
                    else
                        kategoriaEdit.Lun++;
                    kategoriaEdit.Emertimi = kategoria.Emertimi;
                    kategoriaEdit.Pershkrimi = kategoria.Pershkrimi;
                    kategoriaEdit.Lub = Convert.ToInt32(User.Claims.ElementAt(1).Value);
                    kategoriaEdit.Lud = DateTime.Now;
                    _context.Entry(kategoriaEdit).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    _notyf.Custom("Kategoria u editua!", 5, "#FFBC53","fa fa-check");
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(kategoria);
        }

        [HttpPost]
        public  IActionResult Fshi(int id)
        {
            var kategoria = _context.Kategoria.FirstOrDefault(x => x.KategoriaId == id);
            var status = false;
            if (kategoria == null) return Json(status);
            try
            {
                _context.Kategoria.Remove(kategoria);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return Json(status);
        }
    }
}
