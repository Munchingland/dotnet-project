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
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GameRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<Game>> logger) : base(applicationDbContext, logger)
        {
        }

        public Task<IEnumerable<Game>> GetByConsoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> GetByDeveloperAsync(int id)
        {
            throw new NotImplementedException();
        }
        public override IQueryable<Game> GetAll()
        {
            return _table.Include(g => g.Developer).Include(g => g.Platforms).AsQueryable();
        }
        public override async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _table.Include(g => g.Developer).Include(g => g.Platforms).ToListAsync();
        }
        public override async Task<Game> GetByIdAsync(int id)
        {
            return await _table.Include(g=>g.Platforms).Include(g=>g.Developer).FirstOrDefaultAsync(g=>g.Id == id);
        }
        //Maybe be better in a user Repo but waiting on identity for this
        public async Task<IEnumerable<Game>> GetByUserAsync(int id)
        {
            return await _applicationDbContext.GamesUsers.Include(gu=>gu.Game).Where(gu=>gu.UserId == id).Select(g=>g.Game).ToListAsync();
        }
    }
}
