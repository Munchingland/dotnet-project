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
        Task<IEnumerable<Game>> GetByDeveloper(int id);
        Task<IEnumerable<Game>> GetByConsole(int id);
    }
}
