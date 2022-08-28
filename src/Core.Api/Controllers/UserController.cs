using Core.DTOs.User;
using Core.Model.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(UserSignInDto model)
        {
            var response = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            },model.Password);//the password will be encripted by itself

            if (!response.Succeeded)
            {
                throw new Exception("Could not create user");
            }

            return Ok();

        }
    }
}
