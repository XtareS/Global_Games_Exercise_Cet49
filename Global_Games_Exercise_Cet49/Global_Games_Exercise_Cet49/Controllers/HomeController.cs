using Global_Games_Exercise_Cet49.Data;
using Global_Games_Exercise_Cet49.Data.Entities;
using Global_Games_Exercise_Cet49.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Global_Games_Exercise_Cet49.Controllers
{





    public class HomeController : Controller
    {
        private readonly DataContext _context;


        public HomeController(DataContext context)
        {
            _context = context;
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
                return RedirectToAction("Services","Home");
            }
            return View(contacto);
        }



        //registos

        // POST: Registos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tester([Bind("Id,Name,Sur,Adress,Local,CC,Birth,ImageFile")] TesterViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

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


        private Registo  ToTester(TesterViewModel view, string path)
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
                Birth = view.Birth

            };
        }



        private bool TesterExists(int id)
        {
            return _context.Registos.Any(e => e.Id == id);
        }













        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }










    }
}
