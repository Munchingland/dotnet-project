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
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService( IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<ResultModel<Developer>> CreateAsync(string name, DateTime creationDate)
        {
            if(await _developerRepository.GetAll().AnyAsync(d => d.Name.ToUpper().Equals(name.ToUpper())))
            {
                return new ResultModel<Developer>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Name exists!" }
                };
            }
            var developer = new Developer
            {
                Name = name,
                Created = creationDate,
            };
            if(!await _developerRepository.CreateAsync(developer)) 
            {
                return new ResultModel<Developer>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unknown error, please try again later..." }
                };
            }
            return new ResultModel<Developer>
            {
                IsSuccess = true
            };
        }

        public Task<ResultModel<Game>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<Developer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<Developer>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<Developer>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<Developer>> UpdateAsync(int id, string name, DateTime creationDate)
        {
            throw new NotImplementedException();
        }
    }
}
