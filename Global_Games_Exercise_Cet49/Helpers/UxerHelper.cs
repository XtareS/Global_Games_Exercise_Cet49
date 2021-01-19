
namespace Global_Games_Exercise_Cet49.Helpers
{
    using Global_Games_Exercise_Cet49.Data.Entities;
    using Global_Games_Exercise_Cet49.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;


    public class UxerHelper : IUxerHelper
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UxerHelper(UserManager<User> userXanager, SignInManager<User> signInXanager)
        {
            this.userManager = userXanager;
            this.signInManager = signInXanager;
        }


        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await this.userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false
                );
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await this.userManager.UpdateAsync(user);
        }
    }


}

