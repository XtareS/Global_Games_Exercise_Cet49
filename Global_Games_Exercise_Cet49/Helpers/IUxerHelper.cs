﻿
namespace Global_Games_Exercise_Cet49.Helpers
{
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Models;
    using System.Threading.Tasks;

    public interface IUxerHelper
    {
        Task<User> GetUserByEmailAsync(string email);



        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();


        Task<IdentityResult> UpdateUserAsync(User user);


        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

    }
}
