using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Search(string searchTerm)
        {
            var url = new Uri($"{_baseUrl}/{searchTerm}");
            var result = await _httpClient.GetAsync(url);
            if(!result.IsSuccessStatusCode)
            {
                return BadRequest("Error");
            }
            var content = await result.Content.ReadAsStringAsync();
            var gamesSearchViewModel = JsonConvert.DeserializeObject<GamesSearchViewModel>(content);
            return View(gamesSearchViewModel);
        }
        public async Task<IActionResult> GetByPlatform(int id, string platformName)
        {
            var url = new Uri($"{_baseUrl}/platform/{id}");
            var result = await _httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode)
            {
                return BadRequest("Error");
            }
            var content = await result.Content.ReadAsStringAsync();
            var gamesGetByPlatformViewModel = JsonConvert.DeserializeObject<GamesGetByPlatformViewModel>(content);
            gamesGetByPlatformViewModel.SearchTerm = platformName;
            return View(gamesGetByPlatformViewModel);
        }
        public async Task<IActionResult> GetByDeveloper(int id, string platformName)
        {
            var url = new Uri($"{_baseUrl}/developer/{id}");
            var result = await _httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode)
            {
                return BadRequest("Error");
            }
            var content = await result.Content.ReadAsStringAsync();
            var gamesGetByDeveloperViewModel = JsonConvert.DeserializeObject<GamesGetByDeveloperViewModel>(content);
            gamesGetByDeveloperViewModel.SearchTerm = platformName;
            return View(gamesGetByDeveloperViewModel);
        }
        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Uri deleteUri = new Uri($"{_baseUrl}/{id}");
            var result = await _httpClient.DeleteAsync(deleteUri);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var url = $"{_configuration.GetSection("ApiUrl:BaseUrl").Value}";
            var platformUrl = new Uri($"{url}/Platforms");
            var result = await _httpClient.GetAsync(platformUrl);
            var content = await result.Content.ReadAsStringAsync();
            var platforms = JsonConvert.DeserializeObject<BaseItemsViewModel>(content);
            var developerUrl = new Uri($"{url}/Developers");
            result = await _httpClient.GetAsync(developerUrl);
            content = await result.Content.ReadAsStringAsync();
            var developers = JsonConvert.DeserializeObject<BaseItemsViewModel>(content);
            var gamesAddViewModel = new GamesAddViewModel
            {
                Platforms = platforms.Items.Select(p =>
                new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }),
                Developers = developers.Items.Select(d =>
                new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                })
            };
            gamesAddViewModel.ReleaseDate = DateTime.Now;
            return View(gamesAddViewModel);
        }
    }
}
