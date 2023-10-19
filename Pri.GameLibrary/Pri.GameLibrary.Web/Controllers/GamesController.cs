using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Pri.GameLibrary.Web.ViewModels;
using System.Text;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Add(GamesAddViewModel gamesAddViewModel)
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
            if (!ModelState.IsValid)
            {
                gamesAddViewModel.Platforms = platforms.Items.Select(p =>
                new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
                gamesAddViewModel.Developers = developers.Items.Select(d =>
                new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                });
                return View(gamesAddViewModel);
            }
            MultipartFormDataContent multipartFormDataContent = new()
            {
                {new StringContent(gamesAddViewModel.Name, Encoding.UTF8), "Name"},
                {new StringContent(gamesAddViewModel.ReleaseDate.ToString(), Encoding.UTF8), "ReleaseDate" },
                {new StringContent(gamesAddViewModel.DeveloperId.ToString(), Encoding.UTF8), "DeveloperId" }
            };
            foreach (var item in gamesAddViewModel.PlatformIds)
            {
                multipartFormDataContent.Add(new StringContent(item.ToString(), Encoding.UTF8), "PlatformIds[]");
            }

            var postResult = await _httpClient.PostAsync(_baseUrl, multipartFormDataContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if(postResult.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Er ging iets mis, probeer later opnieuw...");
            gamesAddViewModel.Platforms = platforms.Items.Select(p =>
               new SelectListItem
               {
                   Text = p.Name,
                   Value = p.Id.ToString()
               });
            gamesAddViewModel.Developers = developers.Items.Select(d =>
            new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            return View(gamesAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var url = new Uri($"{_baseUrl}/{id}");
            var result = await _httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode)
            {
                return NotFound();
            }
            //read the content to serialized string
            var content = await result.Content.ReadAsStringAsync();
            var gamesUpdateViewModel =
                JsonConvert.DeserializeObject<GamesUpdateViewModel>(content);
            var newUrl = $"{_configuration.GetSection("ApiUrl:BaseUrl").Value}";
            var platformUrl = new Uri($"{newUrl}/Platforms");
            result = await _httpClient.GetAsync(platformUrl);
            content = await result.Content.ReadAsStringAsync();
            var platforms = JsonConvert.DeserializeObject<BaseItemsViewModel>(content);
            var developerUrl = new Uri($"{newUrl}/Developers");
            result = await _httpClient.GetAsync(developerUrl);
            content = await result.Content.ReadAsStringAsync();
            var developers = JsonConvert.DeserializeObject<BaseItemsViewModel>(content);
            gamesUpdateViewModel.Platforms = platforms.Items.Select(p =>
                new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
            gamesUpdateViewModel.Developers = developers.Items.Select(d =>
                 new SelectListItem
                 {
                     Text = d.Name,
                     Value = d.Id.ToString()
                 });
            return View(gamesUpdateViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(GamesUpdateViewModel gamesUpdateViewModel)
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
            if (!ModelState.IsValid)
            {
                gamesUpdateViewModel.Platforms = platforms.Items.Select(p =>
                new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
                gamesUpdateViewModel.Developers = developers.Items.Select(d =>
                new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                });
                return View(gamesUpdateViewModel);
            }
            MultipartFormDataContent multipartFormDataContent = new()
            {
                {new StringContent(gamesUpdateViewModel.Name, Encoding.UTF8), "Name"},
                {new StringContent(gamesUpdateViewModel.Id.ToString(), Encoding.UTF8), "Id" },
                {new StringContent(gamesUpdateViewModel.ReleaseDate.ToString(), Encoding.UTF8), "ReleaseDate" },
                {new StringContent(gamesUpdateViewModel.DeveloperId.ToString(), Encoding.UTF8), "DeveloperId" }
            };
            foreach (var item in gamesUpdateViewModel.PlatformIds)
            {
                multipartFormDataContent.Add(new StringContent(item.ToString(), Encoding.UTF8), "PlatformIds[]");
            }

            var putResult = await _httpClient.PutAsync(_baseUrl, multipartFormDataContent);
            var putContent = await putResult.Content.ReadAsStringAsync();
            if (putResult.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Er ging iets mis, probeer later opnieuw...");
            gamesUpdateViewModel.Platforms = platforms.Items.Select(p =>
               new SelectListItem
               {
                   Text = p.Name,
                   Value = p.Id.ToString()
               });
            gamesUpdateViewModel.Developers = developers.Items.Select(d =>
            new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            return View(gamesUpdateViewModel);
        }
        public async Task<IActionResult> GetById(int id)
        {
            var url = new Uri($"{_baseUrl}/{id}");
            var result = await _httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode)
            {
                return NotFound();
            }
            //read the content to serialized string
            var content = await result.Content.ReadAsStringAsync();
            var gamesGetByIdViewModel =
                JsonConvert.DeserializeObject<GamesGetByIdViewModel>(content);
            return View(gamesGetByIdViewModel);
        }
    }
}
