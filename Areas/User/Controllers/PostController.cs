using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NgeblogLagi.Data;
using NgeblogLagi.Helper;
using NgeblogLagi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NgeblogLagi.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext c)
        {
            _context = c;
        }
        public IActionResult Index()
        {
            var post = _context.Posts
                .Include(x => x.User)
                .Select(x => new PostDTO()
                {
                    Title = x.Title,
                    Content = x.Content,
                    Name = x.User.Name,
                    Update_Date = x.Update_Date
                }).ToList();

            var jmlpost = _context.Posts.Count();
            var jmluser = _context.Users.Count();

            ViewBag.post = jmlpost;
            ViewBag.user = jmluser;
            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post parameter)
        {
            if (ModelState.IsValid)
            {
                parameter.Create_Date = DateTime.Now;
                parameter.PostId = parameter.Create_Date.Ticks.ToString();
                parameter.Update_Date = DateTime.Now;
                parameter.Status = true;
                var isi = User.GetUsername();
                //parameter.User = User.GetUsername();
                _context.Add(parameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        public IActionResult ListEdit()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
