using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pri.GameLibrary.Web.ViewModels;

namespace Pri.GameLibrary.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public DevelopersController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _baseUrl = $"{_configuration.GetSection("ApiUrl:BaseUrl").Value}/Developers";
        }

        public async Task<IActionResult> Get(int id)
        {
            var url = new Uri($"{_baseUrl}/{id}");
            var result = await _httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode)
            {
                return NotFound();
            }
            //read the content to serialized string
            var content = await result.Content.ReadAsStringAsync();
            var developersGetViewModel =
                JsonConvert.DeserializeObject<DevelopersGetViewModel>(content);
            return View(developersGetViewModel);
        }
    }
}
