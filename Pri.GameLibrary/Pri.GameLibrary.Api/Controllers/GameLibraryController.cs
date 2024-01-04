using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Api.DTOs;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Api.DTOs.Request;

namespace Pri.GameLibrary.Api.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class GameLibraryController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;

        public GameLibraryController(IUserService userService, IGameService gameService, IReviewService reviewService)
        {
            _userService = userService;
            _gameService = gameService;
            _reviewService = reviewService;
        }

        [HttpGet]
        [HttpGet("user/{id:int}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var result = await _gameService.GetByUserAsync(id);
            var gamesGetAllDto = new GamesGetAllDto();
            gamesGetAllDto.Items = result.Items
                .Select(g => new GamesGetByIdDto
                {
                    Name = g.Name,

                    Developer = new BaseDto
                    {
                        Id = g.Developer.Id,
                        Name = g.Developer.Name,
                    },
                    ReleaseDate = g.Created.Date,
                    Platforms = g.Platforms.Select(p => new BaseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }),
                    Id = g.Id,
                    AverageReview = _reviewService.GetGivenScoreAsync(g.Id, id).Result,
                });

            return Ok(gamesGetAllDto);
        }

        [HttpGet("NotUser/{id:int}")]
        public async Task<IActionResult> GetNotOwnedByUserId(string id)
        {
            var result = await _gameService.GetByNotOwnedByUserAsync(id);
            var gamesGetAllDto = new GamesGetAllDto();
            gamesGetAllDto.Items = result.Items
                .Select(g => new GamesGetByIdDto
                {
                    Name = g.Name,

                    Developer = new BaseDto
                    {
                        Id = g.Developer.Id,
                        Name = g.Developer.Name,
                    },
                    ReleaseDate = g.Created.Date,
                    Platforms = g.Platforms.Select(p => new BaseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }),
                    Id = g.Id,
                    AverageReview = _reviewService.GetAverageScoreAsync(g.Id).Result
                });

            return Ok(gamesGetAllDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LibraryAddDto libraryAddDto)
        {
            var result = await _userService.AddToLibraryAsync(libraryAddDto.UserId, libraryAddDto.GameId);
            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("Added");
        }

        [HttpDelete("{userId}/{gameId}")]
        public async Task<IActionResult> Remove(string userId, int gameId)
        {
            var result = await _userService.DeleteAsync(userId, gameId);
            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("Removed");
        }
    }
}
