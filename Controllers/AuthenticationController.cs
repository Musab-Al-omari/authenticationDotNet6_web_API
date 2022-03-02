using System.Security.Claims;
using authenticationDotNet6_web_API.Dto;
using authenticationDotNet6_web_API.models;
using authenticationDotNet6_web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace authenticationDotNet6_web_API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManger;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenServices _tokenServices;

        public AuthenticationController(ILogger<AuthenticationController> logger, UserManager<User> userManger, TokenServices tokenServices, SignInManager<User> signInManager)
        {
            this._tokenServices = tokenServices;
            this._signInManager = signInManager;
            this._userManger = userManger;
            this._logger = logger;
        }


        [Authorize]
        [HttpGet]
        [Route("user")]
        public async Task<ActionResult<User>> GetUser()
        {
            var user = await _userManger.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return user;
        }

        [Authorize]
        [HttpGet]
        [Route("string")]
        public async Task<ActionResult<string>> GetString()
        {
            return "i am string ";
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserReturnDto>> Login(LoginDto loginDto)
        {


            var user = await _userManger.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return new UserReturnDto
                {
                    DisplayName = user.DisplayName,
                    token = _tokenServices.CreateToken(user)
                };
            }

            return Unauthorized();

        }


        [HttpPost("register")]
        public async Task<ActionResult<UserReturnDto>> Register(RegisterDto registerDto)
        {

            if (await _userManger.Users.AnyAsync(dbUser => dbUser.Email == registerDto.Email))
            {
                return BadRequest("Email taken");
            }

            if (await _userManger.Users.AnyAsync(dbUser => dbUser.UserName == registerDto.Username))
            {
                return BadRequest("Username taken");
            }

            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
                DisplayName = registerDto.DisplayName,
            };

            var result = await _userManger.CreateAsync(user, registerDto.Password);


            if (result.Succeeded)
            {

                return new UserReturnDto
                {
                    DisplayName = user.DisplayName,
                    token = _tokenServices.CreateToken(user)
                };

            }

            return BadRequest("someThing went wrong");
        }


    }
}