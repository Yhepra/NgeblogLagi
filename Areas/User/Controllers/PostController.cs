using Microsoft.AspNetCore.Mvc;

namespace NgeblogLagi.Areas.User.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
