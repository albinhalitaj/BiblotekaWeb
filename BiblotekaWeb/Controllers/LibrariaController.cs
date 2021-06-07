using Microsoft.AspNetCore.Mvc;

namespace BiblotekaWeb.Controllers
{
    public class LibrariaController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}