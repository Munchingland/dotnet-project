using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Request;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Core.Services;

namespace Pri.GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByGameId(int id)
        {
            var result = await _reviewService.GetByGameIdAsync(id);
            var reviewGetByGameIdDto = new ReviewGetByGameIdDto
            {
                Items = result.Items.Select(r => new ReviewGetByIdDto
                {
                    Created = r.Created.ToShortDateString(),
                    Description = r.Description,
                    Id = r.Id,
                    Rating = r.Rating,
                })
            };
            return Ok(reviewGetByGameIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewsCreateDto reviewsCreateDto)
        {
            var result = await _reviewService.CreateAsync(reviewsCreateDto.Description, reviewsCreateDto.Score, reviewsCreateDto.UserId, reviewsCreateDto.GameId);
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
        public async Task<IActionResult> Update(ReviewsUpdateDto reviewsUpdateDto)
        {
            if(!await _reviewService.ExistsAsync(reviewsUpdateDto.ReviewId))
            {
                return NotFound();
            }
            var result = await _reviewService.UpdateAsync(reviewsUpdateDto.Description, reviewsUpdateDto.Score, reviewsUpdateDto.ReviewId);
            if( !result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _reviewService.ExistsAsync(id))
            {
                return NotFound();
            }
            var result = await _reviewService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Deleted");
        }
    }
}
