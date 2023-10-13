using Microsoft.AspNetCore.Mvc;

namespace Pri.GameLibrary.Api.Controllers
{
    public class DevelopersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
