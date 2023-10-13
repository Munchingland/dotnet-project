using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pri.GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _gameService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            var gamesGetByIdDto = new GamesGetByIdDto();
            gamesGetByIdDto.MapToDto(result.Items.First());
            gamesGetByIdDto.AverageReview = await _reviewService.GetAverageScoreAsync(id);

            return Ok(gamesGetByIdDto);
        }
    }
}
