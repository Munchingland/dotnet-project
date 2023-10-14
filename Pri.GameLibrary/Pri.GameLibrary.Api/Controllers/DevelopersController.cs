using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Request;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Api.DTOs;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Api.Extensions;
using Pri.GameLibrary.Core.Services;

namespace Pri.GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : Controller
    {

        private readonly IDeveloperService _developerService;

        public DevelopersController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _developerService.GetAllAsync();
            var developersGetAllDto = new DevelopersGetAllDto();
            developersGetAllDto.MapToDto(result);
            return Ok(developersGetAllDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _developerService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            var developersGetById = new DevelopersGetByIdDto();
            developersGetById.MapToDto(result.Items.First(), result.Items.First().Games.Count);

            return Ok();
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var result = await _developerService.SearchByNameAsync(name);
            var developersSearchByNameDto = new DevelopersSearchByNameDto();
            developersSearchByNameDto.MapToDto(result);
            return Ok(developersSearchByNameDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DevelopersCreateDto developersCreateDto)
        {
            var result = await _developerService.CreateAsync(developersCreateDto.Name, developersCreateDto.CreationDate);
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
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(!await _developerService.ExistsAsync(id))
            {
                return NotFound();
            }
            var result = await _developerService.DeleteAsync(id);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Deleted");
        }
    }
}
