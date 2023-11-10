using Microsoft.Extensions.Configuration;
using Pri.GameLibrary.Api.DTOs.Account;
using Pri.GameLibrary.Api.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultModel> LoginAsync(string email, string password);
        Task<AuthenticationResultModel> RegisterAsync(RegisterRequestDto registerRequestDto);
    }
}
