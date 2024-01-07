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
            var gameLibraryGetByIdDto = new GameLibraryGetByUserIdDto();

            foreach (var game in result.Items){
                var gameLibraryGetOwnedGamesInfoDto = new GameLibraryGetOwnedGamesInfoDto();
                gameLibraryGetOwnedGamesInfoDto.Name = game.Name;
                gameLibraryGetOwnedGamesInfoDto.Developer = new BaseDto
                {
                    Id = game.Developer.Id,
                    Name = game.Developer.Name,
                };
                gameLibraryGetOwnedGamesInfoDto.ReleaseDate = game.Created.Date;
                gameLibraryGetOwnedGamesInfoDto.Platforms = game.Platforms.Select(p => new BaseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                });
                gameLibraryGetOwnedGamesInfoDto.Id = game.Id;
                var reviewId = await _reviewService.GetReviewIdAsync(game.Id, id);
                var reviews = await _reviewService.GetByIdAsync(reviewId);
                gameLibraryGetOwnedGamesInfoDto.AverageReview = await _reviewService.GetGivenScoreAsync(game.Id, id);
                if (reviews.IsSuccess)
                {
                    foreach(var review in reviews.Items)
                    {
                        gameLibraryGetOwnedGamesInfoDto.AverageReview = review.Rating;
                        gameLibraryGetOwnedGamesInfoDto.Description = review.Description;
                        gameLibraryGetOwnedGamesInfoDto.ReviewId = review.Id;
                        gameLibraryGetOwnedGamesInfoDto.HasReviewed = true;
                    } 
                }
                gameLibraryGetByIdDto.Items.Add(gameLibraryGetOwnedGamesInfoDto);
            }

            return Ok(gameLibraryGetByIdDto);
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
                    AverageReview = _reviewService.GetAverageScoreAsync(g.Id).Result,
                    AmountOfReviews = _reviewService.GetAmountOfReviewsAsync(g.Id).Result,
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
