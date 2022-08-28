using Core.DTOs.User;
using Core.Model.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.User
{
    public interface IUserService
    {
        Task SignUpAsync(UserSignInDto model);
        Task LogInAsync(UserLogInDto model);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task LogInAsync(UserLogInDto model)
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

        }

        public async Task SignUpAsync(UserSignInDto model)
        {
            var response = await _userManager.CreateAsync(new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email
            }, model.Password);

            if (!response.Succeeded)
            {
                throw new Exception("Could not create user");
            }


        }
    }
}
