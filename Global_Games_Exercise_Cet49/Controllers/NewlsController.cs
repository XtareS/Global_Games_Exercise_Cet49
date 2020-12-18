using Global_Games_Exercise_Cet49.Data;
using Global_Games_Exercise_Cet49.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Global_Games_Exercise_Cet49.Controllers
{
    public class NewlsController : Controller
    {
        private readonly DataContext _context;

        public NewlsController(DataContext context)
        {
            _context = context;
        }



        // GET: Newls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mail")] Newl newl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newl);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View();
        }

    }
}
