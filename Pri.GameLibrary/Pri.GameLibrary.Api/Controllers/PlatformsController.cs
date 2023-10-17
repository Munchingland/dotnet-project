using Microsoft.AspNetCore.Mvc;

namespace Pri.GameLibrary.Api.Controllers
{
    public class PlatformsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
