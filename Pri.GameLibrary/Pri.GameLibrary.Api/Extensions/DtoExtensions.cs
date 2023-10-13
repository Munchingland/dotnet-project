using Microsoft.AspNetCore.Server.IIS.Core;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Api.DTOs;
using Pri.GameLibrary.Core.Interfaces.Services;

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
    }
}
