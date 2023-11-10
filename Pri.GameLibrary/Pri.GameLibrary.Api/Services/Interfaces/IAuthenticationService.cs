using Microsoft.Extensions.Configuration;
using Pri.GameLibrary.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResultModel> LoginAsync(string email, string password, IConfiguration configuration);
    }
}
