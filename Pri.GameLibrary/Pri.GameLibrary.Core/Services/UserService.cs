using Microsoft.EntityFrameworkCore;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Repositories;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;

        public UserService(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }

        public async Task<LibraryResultModel> AddToLibraryAsync(string userId, int gameId)
        {
            if(await ExistsAsync(userId, gameId))
            {
                var userGame = new GameUser
                {
                    GameId = gameId,
                    UserId = userId,
                };
                if (!await _userRepository.AddGameToUserLibraryAsync(userGame))
                {
                    return new LibraryResultModel
                    {
                        IsSuccess = false,
                        Errors = new List<string>() { "Unknown error, please try again later..." }
                    };
                }
                return new LibraryResultModel { IsSuccess = true };
            }
            return new LibraryResultModel
            {
                IsSuccess = false,
                Errors = new List<string>() { "User or game does not exist" }
            };
        }

        public async Task<LibraryResultModel> DeleteAsync(string userId, int gameId)
        {
            if (await ExistsAsync(userId, gameId))
            {
                var userGame = await _userRepository.GetGameUser(userId, gameId);
                if (!await _userRepository.RemoveFromLibraryAsync(userGame))
                {
                    return new LibraryResultModel
                    {
                        IsSuccess = false,
                        Errors = new List<string>() { "Unknown error, please try again later..." }
                    };
                }
                return new LibraryResultModel { IsSuccess = true };
            }
            return new LibraryResultModel
            {
                IsSuccess = false,
                Errors = new List<string>() { "User or game does not exist" }
            };
        }

        public async Task<bool> ExistsAsync(string userId, int gameId)
        {
            var users = _userRepository.GetUsers();
            var games = _gameRepository.GetAll();
            if(await users.AnyAsync(u=> u.Id == userId) && await games.AnyAsync(g=>g.Id == gameId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
