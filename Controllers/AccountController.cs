using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NgeblogLagi.Data;
using NgeblogLagi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NgeblogLagi.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext c)
        {
            _context = c;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User datanya)
        {
            var user = _context.Users.Where(x => x.Username == datanya.Username)
                .Include(x => x.Role)
                .FirstOrDefault();

            if (user != null)
            {
                var cekPassword = _context.Users.Where(x => x.Username == datanya.Username
                                                         && x.Password == datanya.Password).FirstOrDefault();

                if (cekPassword != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("Username", user.Username),
                        new Claim("Role", user.Role.Name)
                    };

                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(claims, "Cookies", "Username", "Password")
                        )
                    );

                    if (user.Role.Id == 1)
                    {
                        return Redirect("/admin/home");
                    }
                    else if (user.Role.Id == 2){
                        return Redirect("/user/home");
                    }

                    return RedirectToAction(controllerName: "Home", actionName: "Index");
                }
                ViewBag.pesan = "Password Salah !";
                return View(datanya);
            }

            ViewBag.pesan = "Username Salah !";
            return View(datanya);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User datanya)
        {
            var role = _context.Roles.Where(x => x.Id == 2).FirstOrDefault();
            datanya.Role = role;
            _context.Add(datanya);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
