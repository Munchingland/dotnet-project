using Microsoft.AspNetCore.Mvc;

namespace Pri.Gamelibrary.Vue.Web.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
