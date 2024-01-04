using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : IUserRepository
    {
        private readonly IGameRepository _gameRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(IGameRepository gameRepository, ApplicationDbContext applicationDbContext)
        {
            _gameRepository = gameRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> AddGameToUserLibraryAsync(GameUser addToLibrary)
        {
            _applicationDbContext.GamesUsers.Add(addToLibrary);
            return  await _gameRepository.SaveChangesAsync();
        }

        public async Task<GameUser> GetGameUser(string userId, int gameId)
        {
            var result = _applicationDbContext.GamesUsers.AsQueryable();
            var gameUser = result.FirstOrDefault(g=> g.UserId == userId && g.GameId == gameId);
            return await Task.FromResult(gameUser);
        }

        public IQueryable<User> GetUsers()
        {
            return _applicationDbContext.Users.AsQueryable();
        }

        public async Task<bool> RemoveFromLibraryAsync(GameUser toRemove)
        {
            _applicationDbContext.GamesUsers.Remove(toRemove);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                return false;
            }
        }

    }
}
