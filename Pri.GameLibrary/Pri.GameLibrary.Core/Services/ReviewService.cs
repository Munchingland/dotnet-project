﻿using Pri.GameLibrary.Core.Interfaces.Repositories;
using Pri.GameLibrary.Core.Interfaces.Services;
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
            var reviews = await _reviewRepository.GetByGame(id);
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
    }
}
