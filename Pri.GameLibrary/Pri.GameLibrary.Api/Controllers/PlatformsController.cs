using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Api.Extensions;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Core.Services;

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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _platformService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            var platformsGetByIdDto = new PlatformsGetByIdDto();
            platformsGetByIdDto.MapToDto(result.Items.First());

            return Ok(platformsGetByIdDto);
        }
    }
}
