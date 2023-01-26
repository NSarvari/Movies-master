using Microsoft.AspNetCore.Identity;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Status> Login(Login login)
        {
            var status = new Status();
            var user = await userManager.FindByNameAsync(login.Username);

            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username";
                return status;
            }

            //match Password
            if (!await userManager.CheckPasswordAsync(user, login.Password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, login.Password,false,true);
            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName)
                };

                foreach (var userRole in userRoles)
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, userRole));
                }

                status.StatusCode = 1;
                status.Message = "Logged in successfully";
                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User locked out";
                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error on logging in";
                return status;
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Status> Registration(Registration registration)
        {
            var status = new Status();
            var userExist = await userManager.FindByIdAsync(registration.UserName);
            if (userExist!=null)
            {
                status.StatusCode = 0;
                status.Message = "User Already Exists.";
            }

            ApplicationUser user = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = registration.Name,
                Email = registration.Email,
                UserName = registration.UserName,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, registration.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User registration failed";
                return status;
            }

            //role management
            if (!await roleManager.RoleExistsAsync(registration.Role))
            {
                await roleManager.CreateAsync(new IdentityRole(registration.Role));
            }

            if (await roleManager.RoleExistsAsync(registration.Role))
            {
                await userManager.AddToRoleAsync(user, registration.Role);
            }

            status.StatusCode = 1;
            status.Message = "User has been registered successfuly";
            return status;
        }
    }
}
