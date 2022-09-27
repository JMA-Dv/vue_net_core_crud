using Core.DTOs.Identity;
using Core.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Services.Common.Pagination;
using Service.Services.User;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //private readonly IConfiguration _configuration;

        //public UserController(IUserService userService, IConfiguration configuration)
        //{
        //    _userService = userService;
        //    _configuration = configuration;
        //}

        //[HttpPost("signUp")]
        //public async Task<IActionResult> signUp(UserSignUpDto model)
        //{
        //    await _userService.SignUpAsync(model);
        //    return Ok();
        //}

        //[HttpPost("logIn")]
        //public async Task<IActionResult> LogIn(UserLogInDto model)
        //{
        //    var user = await _userService.LogInAsync(model);
        //    var key = _configuration.GetSection("Keys").GetValue<string>("SecretKey");

        //    var token = await _userService.GenerateTokenAsync(user, key);
        //    return Ok(token); 
        //}

        [HttpGet]
        public async Task<PaginatedList<ApplicationUserDto>> GetAll(int page, int take) => await _userService.GetUserPaginated(page, take);


    }
}
