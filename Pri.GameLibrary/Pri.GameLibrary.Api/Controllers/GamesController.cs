using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.GameLibrary.Api.DTOs;
using Pri.GameLibrary.Api.DTOs.Response;
using Pri.GameLibrary.Api.Extensions;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services;
using System.Xml.Linq;
using System;
using Pri.GameLibrary.Api.DTOs.Request;
using Pri.GameLibrary.Core.Interfaces.Services.Models;

namespace Pri.GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IReviewService _reviewService;

        public GamesController(IGameService gameService, IReviewService reviewService)
        {
            _gameService = gameService;
            _reviewService = reviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameService.GetAllAsync();
            var gamesGetAllDto = new GamesGetAllDto();
            gamesGetAllDto.Items = result.Items
                .Select(g => new GamesGetByIdDto
                {
                    Name = g.Name,
                    
                    Developer = new BaseDto
                    {
                        Id = g.Developer.Id,
                        Name = g.Developer.Name,
                    },
                    ReleaseDate = g.Created.Date,
                    Platforms = g.Platforms.Select(p => new BaseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }),
                    Id = g.Id,
                    AverageReview = _reviewService.GetAverageScoreAsync(g.Id).Result
                });
            return Ok(gamesGetAllDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _gameService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            var gamesGetByIdDto = new GamesGetByIdDto();
            gamesGetByIdDto.MapToDto(result.Items.First());
            gamesGetByIdDto.AverageReview = await _reviewService.GetAverageScoreAsync(id);

            return Ok(gamesGetByIdDto);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var result = await _gameService.SearchByNameAsync(name);
            var searchByNameDto = new GamesSearchByNameDto
            {
                Items = result.Items.Select(g => new GamesGetByIdDto
                {
                    Name = g.Name,

                    Developer = new BaseDto
                    {
                        Id = g.Developer.Id,
                        Name = g.Developer.Name,
                    },
                    ReleaseDate = g.Created.Date,
                    Platforms = g.Platforms.Select(p => new BaseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }),
                    Id = g.Id,
                    AverageReview = _reviewService.GetAverageScoreAsync(g.Id).Result
                })
            };
            return Ok(searchByNameDto);
        }
        [HttpGet("platform/{id:int}")]
        public async Task<IActionResult> GetByPlatformId(int id)
        {
            var result = await _gameService.GetByPlatformAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            var gamesGetByPlatformIdDto = new GamesGetByPlatformIdDto();
            gamesGetByPlatformIdDto.Items = result.Items
                .Select(g => new GamesGetByIdDto
                {
                    Name = g.Name,

                    Developer = new BaseDto
                    {
                        Id = g.Developer.Id,
                        Name = g.Developer.Name,
                    },
                    ReleaseDate = g.Created.Date,
                    Platforms = g.Platforms.Select(p => new BaseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }),
                    Id = g.Id,
                    AverageReview = _reviewService.GetAverageScoreAsync(g.Id).Result
                });

            return Ok(gamesGetByPlatformIdDto);
        }
        [HttpGet("developer/{id:int}")]
        public async Task<IActionResult> GetByDeveloperId(int id)
        {
            var result = await _gameService.GetByDeveloperAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            var gamesGetByDeveloperIdDto = new GamesGetByDeveloperIdDto();
            gamesGetByDeveloperIdDto.Items = result.Items
                .Select(g => new GamesGetByIdDto
                {
                    Name = g.Name,

                    Developer = new BaseDto
                    {
                        Id = g.Developer.Id,
                        Name = g.Developer.Name,
                    },
                    ReleaseDate = g.Created.Date,
                    Platforms = g.Platforms.Select(p => new BaseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }),
                    Id = g.Id,
                    AverageReview = _reviewService.GetAverageScoreAsync(g.Id).Result
                });

            return Ok(gamesGetByDeveloperIdDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm]GamesCreateDto gamesCreateDto)
        {
            var result = await _gameService.CreateAsync(gamesCreateDto.Name, gamesCreateDto.DeveloperId, gamesCreateDto.PlatformIds, gamesCreateDto.ReleaseDate);
            if (!result.IsSuccess)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("Created");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]GamesUpdateDto gamesUpdateDto)
        {
            if(!await _gameService.ExistsAsync(gamesUpdateDto.Id))
            {
                return NotFound();
            }
            var gameUpdateModel = new GameUpdateModel
            {
                DeveloperId = gamesUpdateDto.DeveloperId,
                Id = gamesUpdateDto.Id,
                ReleaseDate = gamesUpdateDto.ReleaseDate,
                Name = gamesUpdateDto.Name,
                PlatformIds = gamesUpdateDto.PlatformIds,
            };
            var result = await _gameService.UpdateAsync(gameUpdateModel);
            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _gameService.ExistsAsync(id))
            {
                return NotFound();
            }
            var result = await _gameService.DeleteAsync(id);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Deleted");
        }
    }
}
