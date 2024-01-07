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
    public class ReviewService : BaseService<IReviewRepository, Review>, IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IGameService _gameService;
        private IUserService _userService;
        private IUserRepository _userRepository;

        public ReviewService(IReviewRepository reviewRepository, IGameService gameService, IUserService userService, IUserRepository userRepository) : base(reviewRepository)
        {
            _reviewRepository = reviewRepository;
            _gameService = gameService;
            _userService = userService;
            _userRepository = userRepository;
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
            if (review == null)
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
            result = result.Where(r => r != null);
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

        public async Task<ResultModel<Review>> CreateAsync(string description, int score, string userId, int gameId)
        {
            if (!await _userService.ComboExistsAsync(userId, gameId))
            {
                return new ResultModel<Review>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "User does not have game" }
                };
            }
            var review = new Review
            {
                Description = description,
                Created = DateTime.Now,
                Rating = score,
            };

            if (!await _reviewRepository.CreateAsync(review))
            {
                return new ResultModel<Review>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unknown error, please try again later..." }
                };
            }
            else
            {
                var reviews = _reviewRepository.GetAll();
                var reviewOfUser = reviews.OrderBy(r => r.Created).Last();
                var gameUser = await _userRepository.GetGameUserAsync(userId, gameId);
                gameUser.ReviewId = reviewOfUser.Id;
                if (!await _userRepository.UpdateGameUserAsync(gameUser))
                {
                    return new ResultModel<Review>
                    {
                        IsSuccess = false,
                        Errors = new List<string>() { "Unknown error, please try again later..." }
                    };
                }

                return new ResultModel<Review>
                {
                    IsSuccess = true,
                };
            }

        }
        public async Task<ResultModel<Review>> UpdateAsync(string description, int score, int reviewId)
        {
            var toUpdate = await _reviewRepository.GetByIdAsync(reviewId);
            toUpdate.Created = DateTime.Now;
            toUpdate.Description = description;
            toUpdate.Rating = score;
            if (await _reviewRepository.UpdateAsync(toUpdate))
            {
                return new ResultModel<Review>
                {
                    IsSuccess = true,
                };
            }
            return new ResultModel<Review> 
            { 
                IsSuccess = false,
                Errors = new List<string> { "Something went wrong, please try again later..." }
            };
        }

        public async Task<int> GetReviewIdAsync(int gameId, string userId)
        {
            var review = await _reviewRepository.GetByUserAsync(gameId, userId);
            if (review == null)
            {
                return 0;
            }
            return review.Id;
        }
    }
}
