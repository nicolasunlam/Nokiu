using Microsoft.AspNetCore.Mvc;

namespace Nokiu.WebApplication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
