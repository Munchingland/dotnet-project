using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> BothExistAsync(string userId,int gameId);
        Task<LibraryResultModel> DeleteAsync(string userId, int gameId);
        Task<LibraryResultModel> AddToLibraryAsync(string userId, int gameId);
        Task<bool> ComboExistsAsync(string userId, int gameId);

    }
}
