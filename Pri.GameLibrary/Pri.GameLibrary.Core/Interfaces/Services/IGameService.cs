﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IGameService : IBaseService<Game>
    {
        Task<ResultModel<Game>> CreateAsync(string name, int developerId, IEnumerable<int> platformIds, DateTime releaseDate);
        Task<ResultModel<Game>> UpdateAsync(GameUpdateModel gameUpdateModel);
        Task<ResultModel<Game>> SearchByNameAsync(string name);
        Task<ResultModel<Game>> GetByUserAsync(string id);
        Task<ResultModel<Game>> GetByDeveloperAsync(int id);
        Task<ResultModel<Game>> GetByPlatformAsync(int id);
        Task<ResultModel<Game>> GetByNotOwnedByUserAsync(string id);
    }
}
