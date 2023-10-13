using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
    public class BaseService<TOne, TTwo> : IBaseService<TTwo>
        where TOne : IBaseRepository<TTwo>
        where TTwo : BaseEntity

    {
        private readonly IBaseRepository<TTwo> _repo;

        public BaseService(IBaseRepository<TTwo> repo)
        {
            _repo = repo;
        }

        public async Task<ResultModel<TTwo>> DeleteAsync(int id)
        {

            var toDelete = await _repo.GetByIdAsync(id);
            if (!await _repo.DeleteAsync(toDelete))
            {
                return new ResultModel<TTwo>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Unknown error, please try again later..." }
                };
            }
            return new ResultModel<TTwo>
            {
                IsSuccess = true
            };
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var result = _repo.GetAll();
            return await result.AnyAsync(i=>i.Id == id);
        }

        public async Task<ResultModel<TTwo>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return new ResultModel<TTwo>
            {
                IsSuccess = true,
                Items = items
            };
        }

        public async Task<ResultModel<TTwo>> GetByIdAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
            {
                return new ResultModel<TTwo>
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"{nameof(TTwo)} not found" }
                };
            }
            return new ResultModel<TTwo>
            {
                IsSuccess = true,
                Items = new List<TTwo> { item }
            };
        }
    }
}
