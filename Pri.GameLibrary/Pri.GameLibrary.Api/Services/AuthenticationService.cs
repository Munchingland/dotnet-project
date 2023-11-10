using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pri.GameLibrary.Api.DTOs.Account;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services;
using Pri.GameLibrary.Api.Services.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<AuthenticationResultModel> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new AuthenticationResultModel
                {
                    Errors = new List<string>() { "not allowed" },
                    IsSuccess = false,
                };
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, false);
            if (!result.Succeeded)
            {
                return new AuthenticationResultModel
                {
                    Errors = new List<string>() { "not allowed" },
                    IsSuccess = false,
                };
            }
            //get the user roles
            var userRoles = await _userManager.GetRolesAsync(user);
            //get the claims
            var claims = await _userManager.GetClaimsAsync(user);
            //add userId to claims
            claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id));
            //add user roles to claims
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            //generate token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigninKey")));

            var token = new JwtSecurityToken(
                    audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                    issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                    claims: claims,
                    expires: DateTime.Now.AddDays(_configuration.GetValue<int>("JWTConfiguration:TokenExpiration")),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            //serialize token
            var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new AuthenticationResultModel
            {
                IsSuccess = true,
                Token = serializedToken
            };
        }

        public async Task<AuthenticationResultModel> RegisterAsync(RegisterRequestDto registerRequestDto)
        {
            var user = new User
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.Email,
                BirthDay = registerRequestDto.BirthDay,
                HasApprovedTermsAndConditions = registerRequestDto.HasApprovedTermsAndConditions,
            };
            var result = await _userManager.CreateAsync(user, registerRequestDto.Password);
            if (!result.Succeeded)
            {
                return new AuthenticationResultModel
                {
                    IsSuccess = false,
                    Errors = new List<string>()
                    {
                        "Something went wrong"
                    }
                };
            }
            result = await _userManager.AddToRoleAsync(user, "User");
            if(!result.Succeeded)
            {
                return new AuthenticationResultModel
                {
                    IsSuccess = false,
                    Errors = new List<string>()
                    {
                        "Something went wrong"
                    }
                };
            }
            return new AuthenticationResultModel { IsSuccess = true };
        }
    }
}
