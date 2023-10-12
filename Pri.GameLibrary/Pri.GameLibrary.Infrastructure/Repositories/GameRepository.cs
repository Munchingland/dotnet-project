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
        public GameRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<Game>> logger) : base(applicationDbContext, logger)
        {
        }

        public Task<IEnumerable<Game>> GetByConsole(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> GetByDeveloper(int id)
        {
            throw new NotImplementedException();
        }
    }
}
