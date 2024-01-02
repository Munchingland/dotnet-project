using Microsoft.AspNetCore.Mvc;

namespace Pri.Gamelibrary.Vue.Web.Controllers
{
    public class DevelopersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
