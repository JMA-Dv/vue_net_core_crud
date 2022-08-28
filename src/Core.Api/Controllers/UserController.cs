using Core.DTOs.User;
using Core.Model.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(UserSignInDto model)
        {
            await _userService.SignUpAsync(model);
            return Ok();
        }

        [HttpPost("logIn")]
        public async Task<IActionResult> LogIn(UserLogInDto model)
        {
            await _userService.LogInAsync(model);
            return Ok();
        }
    }
}
