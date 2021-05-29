using System;
using System.Collections.Generic;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class HuazimetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Huazo()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Huazo(Huazimi model)
        {
            return View();
        }
    }
}
