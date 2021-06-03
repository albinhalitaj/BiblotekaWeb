using System;
using System.IO;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Data;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class LibriController : Controller
    {
        private IConfiguration Config { get; }
        private IWebHostEnvironment HostEnvironment { get; }
        private readonly ILibriService _libriService;
        private readonly INotyfService _notyfi;
        private readonly BiblotekaWebContext _webContext;

        public LibriController(ILibriService libriService, 
                            INotyfService notyf,
                            BiblotekaWebContext webContext,
                            IConfiguration _config,
                            IWebHostEnvironment hostEnvironment)
        {
            Config = _config;
            HostEnvironment = hostEnvironment;
            _libriService = libriService;
            _notyfi = notyf;
            _webContext = webContext;
        }

        public IActionResult Index()
        {
            var librat = _libriService.GetAllLibri();
            return View(librat); 
        }


        [HttpGet]
        public IActionResult Shto()
        {
            ViewBag.Kategorite = _webContext.Kategoria.ToList();
            ViewBag.Gjuhet = _webContext.Gjuhas.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Shto(Libri libri)
        {
            var id = string.Empty;
            await using (var con = new SqlConnection(Config.GetConnectionString("Conn")))
            {
                id = con.Query<string>("select dbo.LibriID()").FirstOrDefault();
            }
            var wwwRootPath = HostEnvironment.WebRootPath;
            var fileName = libri.Titulli.ToLower() + DateTime.Now.ToString("ddMMyyyy");
            var exts = Path.GetExtension(libri.Image.FileName);
            fileName = fileName.Replace(" ", string.Empty) + exts;
            var path = Path.Combine(wwwRootPath + "/Admin/img/bookImages", fileName);
            await using (var fileStream = new FileStream(path, FileMode.Create))
                await libri.Image.CopyToAsync(fileStream);
            libri.ImageName = fileName;
            libri.InsertBy = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            libri.LibriId = id;
            libri.InsertDate = DateTime.Now;
            _libriService.ShtoLibrin(libri);
            _notyfi.Custom("Libri u shtua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edito(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Kategorite = _webContext.Kategoria.ToList();
            ViewBag.Gjuhet = _webContext.Gjuhas.ToList();
            var libri = _libriService.GetLibriById(id);
            return View(libri);
        }

        [HttpPost]
        public async Task<IActionResult> Edito(string id,Libri libri)
        {
            var liber = _libriService.GetLibriById(id);
            if (liber.Lun == null)
                libri.Lun = 1;
            else
                libri.Lun = liber.Lun + 1;
            libri.Lub = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            libri.Lud = DateTime.Now;
            libri.LibriId = id;
            libri.InsertBy = liber.InsertBy;
            libri.InsertDate = liber.InsertDate;
            libri.ImageName = liber.ImageName;
            _libriService.PerditesoLibrin(libri);
            _notyfi.Custom("Libri u përditësua!", 5, "#FFBC53", "fa fa-check");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var libri = _libriService.GetLibriById(id);
            var imgName = libri.ImageName;
            var result = _libriService.DeleteLibrin(id);
            if (!result) return Json(result);
            var wwwRootPath = HostEnvironment.WebRootPath;
            var path = Path.Combine(wwwRootPath + "/Admin/img/bookImages", imgName);
            if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
            return Json(result);
        }
    }
}
