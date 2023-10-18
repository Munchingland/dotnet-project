using Microsoft.AspNetCore.Mvc;

namespace Pri.GameLibrary.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GamesController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _baseUrl = $"{_configuration.GetSection("ApiUrl:BaseUrl").Value}/Drinks";
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
