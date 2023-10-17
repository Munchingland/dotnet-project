using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Api.Extensions;
using Pri.GameLibrary.Core.Interfaces.Services;

namespace Pri.GameLibrary.Api.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly IPlatformService _platformService;

        public PlatformsController(IPlatformService platformService)
        {
            _platformService = platformService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _platformService.GetAllAsync();
            var platformsGetAllDto = new PlatformsGetAllDto();
            platformsGetAllDto.MapToDo(result);
            return View(platformsGetAllDto);
        }
    }
}
