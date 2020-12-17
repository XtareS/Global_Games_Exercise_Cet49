using Global_Games_Exercise_Cet49.Data;
using Global_Games_Exercise_Cet49.Data.Entities;
using Global_Games_Exercise_Cet49.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /*parte responsavel por assumir a info do form respectivo ao Ctrl "ContactosController" */
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mail,Mensage")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
        }


        /* parte refente à Newsletter */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mail")] Newl newl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newl);
        }












    }
}
