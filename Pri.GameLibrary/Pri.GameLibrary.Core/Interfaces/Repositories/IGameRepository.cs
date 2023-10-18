using Pri.GameLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Repositories
{
    public interface IGameRepository:IBaseRepository<Game>
    {
        Task<IEnumerable<Game>> GetByDeveloperAsync(int id);
        Task<IEnumerable<Game>> GetByPlatformAsync(int id);
        Task<IEnumerable<Game>> GetByUserAsync(int id);
    }
}
