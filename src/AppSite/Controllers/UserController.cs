using Microsoft.AspNetCore.Mvc;

namespace AppSite.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
