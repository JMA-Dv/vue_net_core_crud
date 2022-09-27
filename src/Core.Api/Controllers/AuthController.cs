using Core.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> signUp(UserSignUpDto model)
        {
            await _userService.SignUpAsync(model);
            return Ok();
        }

        [HttpPost("logIn")]
        public async Task<IActionResult> LogIn(UserLogInDto model)
        {
            var user = await _userService.LogInAsync(model);
            var key = _configuration.GetSection("Keys").GetValue<string>("SecretKey");

            var token = await _userService.GenerateTokenAsync(user, key);
            return Ok(token);
        }
    }

}
