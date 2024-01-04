using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Repositories;
using Pri.GameLibrary.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<Review>> logger) : base(applicationDbContext, logger)
        {
            _context = applicationDbContext;
        }

        public async Task<IEnumerable<Review>> GetByGameAsync(int id)
        {
            return await _context.GamesUsers.Include(r=>r.Review).Where(r=>r.GameId == id).Select(r=>r.Review).ToListAsync();
        }

        public async Task<Review> GetByUserAsync(int gameId, string userId)
        {
            var reviews =  await _context.GamesUsers.Include(r => r.Review).Where(r => r.GameId == gameId).ToListAsync();
            return reviews.Where(r=> r.UserId == userId).Select(r=>r.Review).FirstOrDefault();
        }
    }
}
