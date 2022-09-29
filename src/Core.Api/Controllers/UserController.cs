using Core.DTOs.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Common.Pagination;
using Service.Services.User;
using System.Collections.Generic;
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

        //[HttpGet]
        //public async Task<ActionResult<IList<IdentityUser>>> GetAll(int page, int take) => 
        //    await _userService.GetUserPaginated(page, take);

        [HttpGet()]
        public async Task<ActionResult<PaginatedList<ApplicationUserDto>>> GetPaginated(int page, int take) =>
            await _userService.GetAll(page, take);

    }
}
