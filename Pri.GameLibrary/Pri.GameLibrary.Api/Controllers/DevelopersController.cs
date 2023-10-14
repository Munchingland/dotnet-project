using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Request;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Api.DTOs;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Api.Extensions;

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
       
    }
}
