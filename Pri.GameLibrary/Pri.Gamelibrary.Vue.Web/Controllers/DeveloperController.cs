using Microsoft.AspNetCore.Mvc;

namespace Pri.Gamelibrary.Vue.Web.Controllers
{
    public class DeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
