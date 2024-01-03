
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pri.GameLibrary.Api.DTOs.Account;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pri.GameLibrary.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        public AccountController(SignInManager<User> signInManager, IConfiguration configuration, UserManager<User> userManager, IAuthenticationService authenticationService)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var result = await _authenticationService.LoginAsync(loginRequestDto.Email, loginRequestDto.Password);
            if (!result.IsSuccess)
            {
                return Unauthorized();
            }

            return Ok(new TokenDto { BearerToken = result.Token });
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            var result = await _authenticationService.RegisterAsync(registerRequestDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok("User created");
        }

    }
}
