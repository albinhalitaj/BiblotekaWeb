using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class BallinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
