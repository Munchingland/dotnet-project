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
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IDeveloperRepository _developerRepository;

        public GameService(IPlatformRepository platformRepository, IDeveloperRepository developerRepository, IGameRepository gameRepository)
        {
            _platformRepository = platformRepository;
            _developerRepository = developerRepository;
            _gameRepository = gameRepository;
        }

        public async Task<ResultModel<Game>> CreateAsync(string name, int developerId, IEnumerable<int> platformIds, DateTime releaseDate)
        {
            var platforms = _platformRepository.GetAll();
            if(!platformIds.All(pl => platforms.Any(p => p.Id == pl)))
            {
                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unkown Platform" }
                };
            }
            var developer = _developerRepository.GetAll();
            if(!await developer.AnyAsync(d=>d.Id == developerId))
            {
                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unkown Developer" }
                };
            }
            if( await _gameRepository.GetAll().AnyAsync(g => g.Name.ToUpper().Equals(name.ToUpper())))
            {
                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Name exists!" }
                };
            }
            var game = new Game
            {
                Name = name,
                Created = releaseDate,
                Platforms = _platformRepository.GetAll().Where(p => platformIds.Contains(p.Id)).ToList(),
                DeveloperId = developerId,
            };
            if(!await _gameRepository.CreateAsync(game))
            {
                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unknown error, please try again later..." }
                };
            }
            return new ResultModel<Game>
            {
                IsSuccess = true
            };

        }

        public async Task<ResultModel<Game>> DeleteAsync(int id)
        {
            var toDelete = await _gameRepository.GetByIdAsync(id);
            if(!await _gameRepository.DeleteAsync(toDelete))
            {
                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unknown error, please try again later..." }
                };
            }
            return new ResultModel<Game>
            {
                IsSuccess = true
            };
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _gameRepository.GetAll().AnyAsync(g=>g.Id == id);
        }

        public async Task<ResultModel<Game>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            return new ResultModel<Game>
            {
                IsSuccess = true,
                Items = games
            };
        }

        public async Task<ResultModel<Game>> GetByIdAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if(game == null)
            {
                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Game not found" }
                };
            }
            return new ResultModel<Game>
            {
                IsSuccess = true,
                Items = new List<Game> { game }
            };
        }

        public Task<ResultModel<Game>> SearchByNameAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<Game>> UpdateAsync(int id, string name, int developerId, IEnumerable<int> platformIds)
        {
            throw new NotImplementedException();
        }
    }
}
