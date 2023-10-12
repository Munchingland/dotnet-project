using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IGameService
    {
        Task<ResultModel<Game>> GetAllAsync();
        Task<ResultModel<Game>> GetByIdAsync(int id);
        Task<ResultModel<Game>> CreateAsync();
        Task<ResultModel<Game>> UpdateAsync(int id);
        Task<ResultModel<Game>> SearchByNameAsync(string search);
        Task<bool> ExistsAsync(int id);
        Task<ResultModel<Game>> DeleteAsync(int id);

    }
}
