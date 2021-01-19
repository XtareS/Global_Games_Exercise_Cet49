
namespace Global_Games_Exercise_Cet49.Controllers
{
    using Global_Games_Exercise_Cet49.Data;
    using Global_Games_Exercise_Cet49.Data.Entities;
    using Global_Games_Exercise_Cet49.Helpers;
    using Global_Games_Exercise_Cet49.Migrations;
    using Global_Games_Exercise_Cet49.Models;
using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;



    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IUxerHelper uxerHelper;

        public HomeController(DataContext context, IUxerHelper uxerHelper)
        {
            _context = context;
            this.uxerHelper = uxerHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        public IActionResult Services()
        {
            ViewData["Message"] = "Your Services page.";

            return View();
        }



        public IActionResult Registo()
        {
            ViewData["Message"] = "YourRegistration page.";

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        //Contactos


        // GET:Dados/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET:Dados/Creater
        public IActionResult Creater()
        {
            return View();
        }



        // POST: Contactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mail,Mensage")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Services", "Home");
            }
            return View(contacto);
        }



        //registos

        // POST: Registos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tester([Bind("Id,Name,Sur,Adress,Local,CC,Birth,ImageUrl,ImageFile,Email")] TesterViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Tester",
                        view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Tester/{view.ImageFile.FileName}";

                }

                var tester = this.ToTester(view, path);



                _context.Add(tester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            return View(view);
        }


        private Registo ToTester(TesterViewModel view, string path)
        {
            return new Registo
            {
                Id = view.Id,
                ImageUrl = path,
                Name = view.Name,
                Sur = view.Sur,
                Adress = view.Adress,
                Local = view.Local,
                CC = view.CC,
                Birth = view.Birth,
                Email = view.Email


            };
        }



        private bool TesterExists(int id)
        {
            return _context.Registos.Any(e => e.Id == id);
        }

        //Login

        public IActionResult Loginer()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "UserLogs");
            }
            return this.View();
        }




        [HttpPost]
        public async Task<IActionResult> Loginer(LoginViewModel model)
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









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }










    }
}
