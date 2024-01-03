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
            if(reviews.Count() == 0)
            {
                return 0;
            }
            foreach(var review in reviews)
            {
                if (review == null)
                {
                    return 0;
                }
            }
            return reviews.Average(r => r.Rating);
        }

        public async Task<ResultModel<Review>> GetByGameIdAsync(int id)
        {
            var result = await _reviewRepository.GetByGameAsync(id);
            return new ResultModel<Review>
            {
                IsSuccess = true,
                Items = result
            };
        }
    }
}
