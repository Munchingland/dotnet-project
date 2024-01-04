using Pri.GameLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddGameToUserLibraryAsync(GameUser addToLibrary);
        Task<bool> RemoveFromLibraryAsync(GameUser toRemove);
        IQueryable<User> GetUsers();

        Task<GameUser> GetGameUser(string userId, int gameId);
    }
}
