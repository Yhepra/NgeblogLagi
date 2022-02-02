using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NgeblogLagi.Data;
using System.Linq;

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
            var post = _context.Posts.ToList();
            return View(post);
        }
    }
}
