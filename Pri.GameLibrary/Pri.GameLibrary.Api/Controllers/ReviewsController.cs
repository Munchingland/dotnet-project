using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Core.Interfaces.Services;

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
    }
}
