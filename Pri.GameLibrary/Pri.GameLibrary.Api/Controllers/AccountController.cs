using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pri.GameLibrary.Api.DTOs.Account;
using Pri.GameLibrary.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pri.GameLibrary.Api.Controllers
{
    [Route("Api/auth")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AccountController(SignInManager<User> signInManager, IConfiguration configuration, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if(user == null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginRequestDto.Password, false, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
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
            return Ok(serializedToken);
        }
    }
}
