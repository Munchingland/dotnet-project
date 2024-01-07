using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IReviewService : IBaseService<Review>
    {
        public Task<double> GetAverageScoreAsync(int id);
        public Task<ResultModel<Review>> GetByGameIdAsync(int id);
        public Task<double> GetGivenScoreAsync(int gameId, string userId);
        public Task<int> GetAmountOfReviewsAsync(int gameId);
        public Task<bool> HasReviewedAsync(int gameId, string userId);
        public Task<ResultModel<Review>> CreateAsync(string description, int score, string userId, int gameId);
        public Task<ResultModel<Review>> UpdateAsync(string description, int score, int reviewId);
        public Task<int> GetReviewIdAsync(int gameId, string userId);
    }
}
