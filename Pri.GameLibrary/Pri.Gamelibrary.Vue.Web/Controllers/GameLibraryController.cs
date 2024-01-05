using Microsoft.AspNetCore.Mvc;

namespace Pri.Gamelibrary.Vue.Web.Controllers
{
    public class GameLibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
