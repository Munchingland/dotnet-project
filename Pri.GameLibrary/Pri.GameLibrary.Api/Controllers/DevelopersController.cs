using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Request;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Api.DTOs;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using Pri.GameLibrary.Core.Interfaces.Services;

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
            developersGetAllDto.Developers = result.Items.Select(d => new DevelopersBaseDto
            {
                AmountOfGames = d.Games.Count(),
                Id = d.Id,
                Name = d.Name,
            });
            return Ok(developersGetAllDto);
        }
        
    }
}
