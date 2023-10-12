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
        public ReviewRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<Review>> logger) : base(applicationDbContext, logger)
        {
        }

        public Task<IEnumerable<Review>> GetByGame(int id)
        {
            throw new NotImplementedException();
        }
    }
}
