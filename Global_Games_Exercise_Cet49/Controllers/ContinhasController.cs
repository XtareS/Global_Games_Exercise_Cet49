
namespace Global_Games_Exercise_Cet49.Controllers
{
    using Global_Games_Exercise_Cet49.Data.Entities;
    using Global_Games_Exercise_Cet49.Helpers;
    using Global_Games_Exercise_Cet49.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class ContinhasController : Controller
    {

        private readonly IUxerHelper uxerHelper;

        public ContinhasController(IUxerHelper uxerHelper)
        {
            this.uxerHelper = uxerHelper;
        }


        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "UserLogs");
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.uxerHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return this.Redirect(this.Request.Query["ReturnUrl"].First());
                    }

                    return this.RedirectToAction("Index", "UserLogs");
                }
            }



            this.ModelState.AddModelError(string.Empty, "Mandas-te ao lado");
            return this.View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await this.uxerHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }


        public IActionResult Conta()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Conta(NewUxerRegistViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.uxerHelper.GetUserByEmailAsync(model.UserName);
                if (user == null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.UserName,
                        UserName = model.UserName
                    };

                    var rexult = await this.uxerHelper.AddUserAsync(user, model.Password);
                    if (rexult != IdentityResult.Success)
                    {
                        this.ModelState.AddModelError(string.Empty, "Nop Meu Chapa, ainda não tem cadastro ;)P .");
                        return this.View(model);
                    }

                    var loginViewModel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        Username = model.UserName
                    };

                    var rexult2 = await this.uxerHelper.LoginAsync(loginViewModel);

                    if (rexult2.Succeeded)
                    {
                        return this.RedirectToAction("Index", "Home");
                    }

                    this.ModelState.AddModelError(string.Empty, "Oh maninho ainda nao tens idade para entrar ;)P.");
                    return this.View(model);
                }

                this.ModelState.AddModelError(string.Empty, "Oh pá, Copiar não vale, este já existe.");
            }

            return this.View(model);
        }


        public async Task<IActionResult> ChangeUxer()
        {
            var user = await this.uxerHelper.GetUserByEmailAsync(this.User.Identity.Name);
            var model = new ChangeUxerViewModel();

            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
            }

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeUxer(ChangeUxerViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var uxer = await this.uxerHelper.GetUserByEmailAsync(this.User.Identity.Name);
                if (uxer != null)
                {
                    uxer.FirstName = model.FirstName;
                    uxer.LastName = model.LastName;
                    var rexponse = await this.uxerHelper.UpdateUserAsync(uxer);
                    if (rexponse.Succeeded)
                    {
                        this.ViewBag.UserMessage = "User outdated";
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, rexponse.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User no Fundão.");
                }
            }

            return this.View(model);
        }



        public IActionResult ChangePassvvord()
        {
            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassvvord(ChangePassvvordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.uxerHelper.GetUserByEmailAsync(this.User.Identity.Name);
                if (user != null)
                {
                    var result = await this.uxerHelper.ChangePasswordAsync(user, model.OldPassword, model.NextPassword);
                    if (result.Succeeded)
                    {
                        return this.RedirectToAction("ChangeUxer");
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Né na Etiopia que se passa fome??");
                }
            }

            return this.View(model);
        }


    }
}
