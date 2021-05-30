using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using BiblotekaWeb.Areas.admin.Models;
using BiblotekaWeb.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace BiblotekaWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private INotyfService Notyf { get; }
        private readonly BiblotekaWebContext _context;

        public AccountController(BiblotekaWebContext context,INotyfService notyf)
        {
            Notyf = notyf;
            _context = context;
        }

        [Route("")] 
        [Route("admin")]
        [Route("admin/account")]
        [Route("admin/account/login")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity is {IsAuthenticated: true})
                return Redirect("/admin/ballina");
            ViewBag.ReturnUrl = returnUrl;
            return View(nameof(Login));
        }
        
        
        [HttpPost]
        public IActionResult Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Perdoruesis.Include(x=>x.Stafi)
                                                        .Include(x => x.Roli)
                                                        .FirstOrDefault(x => x.Username.Equals(model.Username) && x.Password.Equals(model.Password));
                if (user!=null)
                {
                    if (Convert.ToInt32(user.IsActive) == 1)
                    {
                        var claims = new List<Claim>
                        {
                            new(ClaimTypes.Name, string.Concat(user.Stafi.Emri," ",user.Stafi.Mbiemri)),
                            new("Id",Convert.ToString(user.Stafi.StafiId)),
                            new(ClaimTypes.Role, user.Roli.EmriRolit)
                        };
                        var indentityPrincipal =
                            new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimPrincipal = new ClaimsPrincipal(indentityPrincipal);
                        HttpContext.SignInAsync(claimPrincipal);
                        if (!string.IsNullOrEmpty(returnUrl))
                            return LocalRedirect(returnUrl);
                        return RedirectToAction("Index", "Ballina");
                    }
                    Notyf.Error("Llogaria juaj është joaktive!", 5);
                }
                else
                    Notyf.Error("Përdoruesi ose fjalëkalimi është gabim!", 5);
            }
            return View(model);
        }


        public new async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/admin");
        }
    }
}
