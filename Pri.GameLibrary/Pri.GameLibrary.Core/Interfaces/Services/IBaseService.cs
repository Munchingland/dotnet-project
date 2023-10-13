using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<ResultModel<T>> GetAllAsync();
        Task<ResultModel<T>> GetByIdAsync(int id);
        Task<ResultModel<T>> SearchByNameAsync(string name);
        Task<bool> ExistsAsync(int id);
        Task<ResultModel<Game>> DeleteAsync(int id);
    }
}
