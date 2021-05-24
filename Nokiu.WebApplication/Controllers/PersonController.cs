using Microsoft.AspNetCore.Mvc;

namespace Nokiu.WebApplication.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
