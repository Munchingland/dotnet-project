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

        public async Task<ResultModel<Developer>> DeleteAsync(int id)
        {
            var toDelete = await _developerRepository.GetByIdAsync(id);
            if(! await _developerRepository.DeleteAsync(toDelete))
            {
                return new ResultModel<Developer>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unknown error, please try again later..." }
                };
            }
            return new ResultModel<Developer>
            { 
                IsSuccess = false 
            };
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _developerRepository.GetAll().AnyAsync(d=>d.Id == id);
        }

        public async Task<ResultModel<Developer>> GetAllAsync()
        {
            var developers = await _developerRepository.GetAllAsync();
            return new ResultModel<Developer>
            {
                IsSuccess = true,
                Items = developers
            };
        }

        public async Task<ResultModel<Developer>> GetByIdAsync(int id)
        {
            var developer = await _developerRepository.GetByIdAsync(id);
            if(developer == null) 
            {
                return new ResultModel<Developer>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Developer not found" }
                };
            }
            return new ResultModel<Developer>
            {
                IsSuccess = true,
                Items = new List<Developer> { developer }
            };
        }

        public async Task<ResultModel<Developer>> SearchByNameAsync(string name)
        {
            var developers = _developerRepository.GetAll();
            var searchResult = await developers.Where(d=>d.Name.ToUpper() == name.ToUpper()).ToListAsync();
            return new ResultModel<Developer>
            {
                IsSuccess = true,
                Items = searchResult
            };
        }

        public async Task<ResultModel<Developer>> UpdateAsync(int id, string name, DateTime creationDate)
        {
            var toUpdate = await _developerRepository.GetByIdAsync(id);
            if(!toUpdate.Name.ToUpper().Equals(name.ToUpper())
                &&
                await _developerRepository.GetAll().AnyAsync(d => d.Name.ToUpper().Equals(name.ToUpper())))
            {
                return new ResultModel<Developer>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Name exists!" }
                };
            }
            toUpdate.Created = creationDate;
            toUpdate.Name = name;
            if(await _developerRepository.UpdateAsync(toUpdate))
            {
                return new ResultModel<Developer>
                { 
                    IsSuccess = true, 
                };
            }
            return new ResultModel<Developer>
            {
                IsSuccess = false,
                Errors = new List<string> { "Something went wrong, please try again later..." }
            };
        }
    }
}
