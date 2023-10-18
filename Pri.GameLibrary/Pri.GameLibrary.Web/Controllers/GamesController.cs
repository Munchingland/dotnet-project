using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pri.GameLibrary.Web.ViewModels;

namespace Pri.GameLibrary.Web.Controllers
{
    public class GamesController : Controller
    {
 
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public GamesController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _baseUrl = $"{_configuration.GetSection("ApiUrl:BaseUrl").Value}/Games";
        }

        public async Task<IActionResult> Index()
        {
            var url = new Uri(_baseUrl);
            var result = await _httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode)
            {
                return BadRequest("Error");
            }
            var content = await result.Content.ReadAsStringAsync();
            var gamesIndexViewModel = JsonConvert.DeserializeObject<GamesIndexViewModel>(content);
            return View(gamesIndexViewModel);
        }
    }
}
