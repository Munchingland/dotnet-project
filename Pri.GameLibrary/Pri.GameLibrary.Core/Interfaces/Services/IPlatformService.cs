using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IPlatformService: IBaseService<Platform>
    {
        Task<ResultModel<Platform>> CreateAsync(string name, DateTime creationDate);
        Task<ResultModel<Platform>> UpdateAsync(int id, string name, DateTime creationDate);
    }
}
