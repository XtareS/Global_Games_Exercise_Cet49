
namespace Global_Games_Exercise_Cet49.Controllers
{

    using Global_Games_Exercise_Cet49.Data;
    using Global_Games_Exercise_Cet49.Data.Entities;
    using Global_Games_Exercise_Cet49.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;




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


        public IActionResult Testerview()
        {
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
        public async Task<IActionResult> Create([Bind("Id,Name,Sur,Adress,Local,CC,Birth")] Registo registo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registo);
        }




        //Tester

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tester([Bind("Id,ImageFile,Name,Sur,Adress,Local,CC,Birth")] TesterViewModel view)
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
                        "wwwroot\\images\\Testers",
                        view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Testers/{view.ImageFile.FileName}";

                }

                var tester = this.ToTester(view, path);



                _context.Add(tester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            return View(view);
        }


        private Tester ToTester(TesterViewModel view, string path)
        {
            return new Tester
            {
                Id = view.Id,
                Name = view.Name,
                Sur = view.Sur,
                Adress = view.Adress,
                Local = view.Local,
                CC = view.CC,
                Birth = view.Birth,
                ImageUrl = path

            };
        }





        private bool TesterExists(int id)
        {
            return _context.Tester.Any(e => e.Id == id);
        }











        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }










    }
}
