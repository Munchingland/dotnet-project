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
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<Platform>> logger) : base(applicationDbContext, logger)
        {
        }
        public override async Task<IEnumerable<Platform>> GetAllAsync()
        {
            return await _table.Include(g => g.Games).ToListAsync();
        }
    }
}
