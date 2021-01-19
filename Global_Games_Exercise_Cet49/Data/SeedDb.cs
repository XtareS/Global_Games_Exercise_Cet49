
namespace Global_Games_Exercise_Cet49.Data
{
    using Global_Games_Exercise_Cet49.Data.Entities;
    using Global_Games_Exercise_Cet49.Helpers;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {

        private readonly DataContext context;
        private readonly IUxerHelper userHelper;


        public SeedDb(DataContext context, IUxerHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;


        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();


            //TODO: Admin-Email

            var user = await this.userHelper.GetUserByEmailAsync("Admin@crtl.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Admin",
                    LastName = "Xsoul",
                    Email = "Admin@crtl.com",
                    UserName = "Admin@crtl.com",
                    PhoneNumber = "XXXXXXXXXXXXXXX"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456789");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Nop meu chapa, XS nao pudeu criar no Seed");
                }

            }

            if (!this.context.UserLogs.Any())
            {
                this.AddUserLog("User01", user);
                this.AddUserLog("User02", user);
                this.AddUserLog("User03", user);
                this.AddUserLog("User04", user);
                this.AddUserLog("User05", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddUserLog(string name, User user)
        {
            this.context.UserLogs.Add(new UserLog
            {
                Name = name,
                User = user
            });
        }
    }
}
