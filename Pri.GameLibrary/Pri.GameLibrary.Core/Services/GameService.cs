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
    public class GameService : BaseService<IGameRepository, Game>, IGameService
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IGameRepository _gameRepository;
        public GameService(IPlatformRepository platformRepository, IDeveloperRepository developerRepository,IGameRepository repo):  base(repo)
        {
            _platformRepository = platformRepository;
            _developerRepository = developerRepository;
            _gameRepository = repo;
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

        public async Task<ResultModel<Game>> GetByDeveloperAsync(int id)
        {
            var games = await _gameRepository.GetByDeveloperAsync(id);
            return new ResultModel<Game>
            {
                IsSuccess = true,
                Items = games
            };
        }
        public async Task<ResultModel<Game>> GetByPlatformAsync(int id)
        {
            var games = await _gameRepository.GetByPlatformAsync(id);
            return new ResultModel<Game>
            {
                IsSuccess = true,
                Items = games
            };
        }

        public async Task<ResultModel<Game>> GetByUserAsync(int id)
        {
            var games = await _gameRepository.GetByUserAsync(id);
            return new ResultModel<Game>
            {
                IsSuccess = true,
                Items = games
            };
        }

        public async Task<ResultModel<Game>> SearchByNameAsync(string search)
        {
            var games = _gameRepository.GetAll();
            var searchResult = await games.Where(g=>g.Name.ToUpper().Contains(search.ToUpper())).ToListAsync();
            return new ResultModel<Game>
            {
                IsSuccess = true,
                Items = searchResult
            };
        }

        public async Task<ResultModel<Game>> UpdateAsync(GameUpdateModel gameUpdateModel)
        {
            if(!await _developerRepository.GetAll().AnyAsync(d=>d.Id == gameUpdateModel.Id))
            {

                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unkown Developer" }
                };
            }
            var platforms = _platformRepository.GetAll().Count(p=> gameUpdateModel.PlatformIds.Contains(p.Id));
            if(platforms != gameUpdateModel.PlatformIds.Count())
            {
                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Unknown platform" }
                };
            }
            var toUpdate = await _gameRepository.GetByIdAsync(gameUpdateModel.Id);
            if (!toUpdate.Name.ToUpper().Equals(gameUpdateModel.Name.ToUpper())
                &&
                await _gameRepository.GetAll().AnyAsync(g=> g.Name.ToUpper().Equals(gameUpdateModel.Name.ToUpper())))
            {
                return new ResultModel<Game>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Name exists!" }
                };
            }
            toUpdate.Name = gameUpdateModel.Name;
            toUpdate.Created = gameUpdateModel.ReleaseDate;
            toUpdate.DeveloperId = gameUpdateModel.DeveloperId;
            toUpdate.Platforms = await _platformRepository.GetAll().Where(p => gameUpdateModel.PlatformIds.Contains(p.Id)).ToListAsync();
            if(await _gameRepository.UpdateAsync(toUpdate))
            {
                return new ResultModel<Game>
                {
                    IsSuccess = true,
                };
            }
            return new ResultModel<Game>
            {
                IsSuccess = false,
                Errors = new List<string> { "Something went wrong, please try again later..." }
            };
        }
    }
}
