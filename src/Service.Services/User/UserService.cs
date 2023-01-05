using AutoMapper;
using Core.DTOs.Identity;
using Core.DTOs.User;
using Core.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;
using Service.Services.Common.Extensions;
using Service.Services.Common.Helpers;
using Service.Services.Common.Pagination;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.User
{
    public interface IUserService
    {
        Task SignUpAsync(UserSignUpDto model);
        Task<ApplicationUser> LogInAsync(UserLogInDto model);
        Task<string> GenerateTokenAsync(ApplicationUser user, string key);
        Task<List<IdentityUser>> GetUserPaginated(int page, int take);
        Task<PaginatedList<ApplicationUserDto>> GetAll(int page, int take);

    }
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user, string key)
        {
            var acciKey = Encoding.ASCII.GetBytes(key);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(
                    claims
                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(acciKey), SecurityAlgorithms.HmacSha256
            )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }

        public async Task<PaginatedList<ApplicationUserDto>> GetAll(int page, int take)
        {
            var response = await _context.Users.OrderByDescending(x => x.UserName)
                .AsQueryable().            PagedAsync(page, take);

            return _mapper.Map<PaginatedList<ApplicationUserDto>>(response);
        }

        public async Task<List<IdentityUser>> GetUserPaginated(int page, int take)
        {
            var res = await _context.Users.ToListAsync();
            //var response = await _context.Users.OrderByDescending(x => x.UserName)
            //.AsQueryable().
            //PagedAsync(page, take);


            return res;


        }

        public async Task<ApplicationUser> LogInAsync(UserLogInDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new Exception("Credentials are incorrect!");
            }

            var validate = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!validate.Succeeded)
            {
                throw new Exception("Credentials are incorrect!");
            }

            return user;

        }



        public async Task SignUpAsync(UserSignUpDto model)
        {

            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            await _userManager.AddToRoleAsync(user, RoleHelper.Vendor);

            if (!result.Succeeded)
            {
                throw new Exception("Could not create user");
            }


        }
    }
}
