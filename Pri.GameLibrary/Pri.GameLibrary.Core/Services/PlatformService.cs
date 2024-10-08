﻿using Microsoft.EntityFrameworkCore;
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
    public class PlatformService : BaseService<IPlatformRepository, Platform>, IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformService(IPlatformRepository repo): base(repo)
        {
            _platformRepository = repo;
        }

        public async Task<ResultModel<Platform>> CreateAsync(string name, DateTime creationDate)
        {
            if (await _platformRepository.GetAll().AnyAsync(d => d.Name.ToUpper().Equals(name.ToUpper())))
            {
                return new ResultModel<Platform>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Name exists!" }
                };
            }
            var platform = new Platform
            {
                Name = name,
                Created = creationDate,
            };
            if (!await _platformRepository.CreateAsync(platform))
            {
                return new ResultModel<Platform>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unknown error, please try again later..." }
                };
            }
            return new ResultModel<Platform>
            {
                IsSuccess = true
            };
        }

        public async Task<ResultModel<Platform>> SearchByNameAsync(string name)
        {
            var platforms = _platformRepository.GetAll();
            var searchResult = await platforms.Where(d => d.Name.ToUpper() == name.ToUpper()).ToListAsync();
            return new ResultModel<Platform>
            {
                IsSuccess = true,
                Items = searchResult
            };
        }

        public async Task<ResultModel<Platform>> UpdateAsync(int id, string name, DateTime creationDate)
        {
            var toUpdate = await _platformRepository.GetByIdAsync(id);
            if (!toUpdate.Name.ToUpper().Equals(name.ToUpper())
                &&
                await _platformRepository.GetAll().AnyAsync(d => d.Name.ToUpper().Equals(name.ToUpper())))
            {
                return new ResultModel<Platform>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Name exists!" }
                };
            }
            toUpdate.Created = creationDate;
            toUpdate.Name = name;
            if (await _platformRepository.UpdateAsync(toUpdate))
            {
                return new ResultModel<Platform>
                {
                    IsSuccess = true,
                };
            }
            return new ResultModel<Platform>
            {
                IsSuccess = false,
                Errors = new List<string> { "Something went wrong, please try again later..." }
            };
        }
    }
}
