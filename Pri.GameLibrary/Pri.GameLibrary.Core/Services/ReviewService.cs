using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Repositories;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<double> GetAverageScoreAsync(int id)
        {
            var reviews = await _reviewRepository.GetByGameAsync(id);
            reviews = reviews.Where(r => r != null);
            if (reviews.Count() == 0)
            {
                return 0;
            }
            return reviews.Average(r => r.Rating);
        }

        public async Task<double> GetGivenScoreAsync(int gameId, string userId)
        {
            var review = await _reviewRepository.GetByUserAsync(gameId, userId);
            if(review == null)
            {
                return 0;
            }
            return review.Rating;
        }


        public async Task<ResultModel<Review>> GetByGameIdAsync(int id)
        {
            var result = await _reviewRepository.GetByGameAsync(id);
            result = result.Where(r => r != null);
            return new ResultModel<Review>
            {
                IsSuccess = true,
                Items = result
            };
        }

        public async Task<int> GetAmountOfReviewsAsync(int gameId)
        {
            var result = await _reviewRepository.GetByGameAsync(gameId);
            result = result.Where(r=> r != null);
            return result.Count();
        }

        public async Task<bool> HasReviewedAsync(int gameId, string userId)
        {
            var review = await _reviewRepository.GetByUserAsync(gameId, userId);
            if (review == null)
            {
                return false;
            }
            return true;
        }
    }
}
