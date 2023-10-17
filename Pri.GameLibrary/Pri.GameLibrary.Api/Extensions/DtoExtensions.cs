using Microsoft.AspNetCore.Server.IIS.Core;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Api.DTOs;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Core.Interfaces.Services.Models;

namespace Pri.GameLibrary.Api.Extensions
{
    public static class DtoExtensions
    {
        public static void MapToDto(this GamesGetByIdDto gamesGetByIdDto, Game game)
        {
            gamesGetByIdDto.Id = game.Id;
            gamesGetByIdDto.ReleaseDate = game.Created.Date.ToShortDateString();
            gamesGetByIdDto.Developer = new BaseDto
            {
                Id = game.Developer.Id,
                Name = game.Developer.Name,
            };
            gamesGetByIdDto.Platforms = game.Platforms
                .Select(p => new BaseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                });
            gamesGetByIdDto.Name = game.Name;
        }
        public static void MapToDto(this DevelopersBaseDto dto, Developer developer, int amountOfGames)
        {
            dto.Id = developer.Id;
            dto.Name = developer.Name;
            dto.AmountOfGames = amountOfGames;
        }
        public static void MapToDto(this DevelopersGetAllDto dto, ResultModel<Developer> result)
        {
            dto.Developers = result.Items.Select(d => new DevelopersBaseDto
             {
                AmountOfGames = d.Games.Count,
                Id = d.Id,
                Name = d.Name,
             });
        }
        public static void MapToDto(this DevelopersGetByIdDto dto, Developer developer, int amountOfGames)
        {
            dto.Id = developer.Id;
            dto.Name = developer.Name;
            dto.AmountOfGames = amountOfGames;
            dto.Founded = developer.Created;
        }
        public static void MapToDo(this PlatformsGetAllDto dto, ResultModel<Platform> result)
        {
            dto.Platforms = result.Items.Select(p => new PlatformsBaseDto
            {
                AmountOfGames = p.Games.Count,
                Id = p.Id,
                Name = p.Name,
            });
        }
    }
}
