using Microsoft.AspNetCore.Mvc;
using NgeblogLagi.Data;
using NgeblogLagi.Models;
using System.Linq;

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
        public IActionResult Login(User datanya)
        {
            var cariUsername = _context.Users.Where(x => x.Username == datanya.Username).FirstOrDefault();

            if (cariUsername != null)
            {
                var cekPassword = _context.Users.Where(x => x.Username == datanya.Username
                                                         && x.Password == datanya.Password).FirstOrDefault();

                if (cekPassword != null)
                {
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
            _context.Add(datanya);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}
