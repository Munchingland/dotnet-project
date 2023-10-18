using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Request;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Api.Extensions;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Core.Services;

namespace Pri.GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(platformsGetAllDto);
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
        [HttpPost]
        public async Task<IActionResult> Create(PlatformsCreateDto platformsCreateDto)
        {
            var result = await _platformService.CreateAsync(platformsCreateDto.Name, platformsCreateDto.ReleaseDate);
            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("Created");
        }
        [HttpPut]
        public async Task<IActionResult> Update(PlatformsUpdateDto platformsUpdateDto)
        {
            if (!await _platformService.ExistsAsync(platformsUpdateDto.Id))
            {
                return NotFound();
            }
            var result = await _platformService.UpdateAsync(platformsUpdateDto.Id, platformsUpdateDto.Name, platformsUpdateDto.ReleaseDate);
            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _platformService.ExistsAsync(id))
            {
                return NotFound();
            }
            var result = await _platformService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Deleted");
        }
    }
}
