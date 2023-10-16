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
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<Developer>> logger) : base(applicationDbContext, logger)
        {
        }
        public override async Task<IEnumerable<Developer>> GetAllAsync()
        {
            return await _table.Include(g => g.Games).ToListAsync();
        }
        public override async Task<Developer> GetByIdAsync(int id)
        {
            return await _table.Include(d => d.Games).FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
