﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
