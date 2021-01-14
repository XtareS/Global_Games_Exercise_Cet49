using Global_Games_Exercise_Cet49.Data;
using Global_Games_Exercise_Cet49.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Global_Games_Exercise_Cet49.Controllers
{
    public class RegistosController : Controller
    {
        private readonly DataContext _context;

        public RegistosController(DataContext context)
        {
            _context = context;
        }

        // GET: Registos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registos.ToListAsync());
        }

        // GET: Registos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registo = await _context.Registos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registo == null)
            {
                return NotFound();
            }

            return View(registo);
        }

        // GET: Registos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageUrl,Name,Sur,Adress,Local,CC,Birth,Email")] Registo registo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Registo", "Home");
            }
            return View(registo);
        }

        // GET: Registos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registo = await _context.Registos.FindAsync(id);
            if (registo == null)
            {
                return NotFound();
            }
            return View(registo);
        }

        // POST: Registos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,Name,Sur,Adress,Local,CC,Birth,Mail")] Registo registo)
        {
            if (id != registo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistoExists(registo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registo);
        }

        // GET: Registos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registo = await _context.Registos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registo == null)
            {
                return NotFound();
            }

            return View(registo);
        }

        // POST: Registos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registo = await _context.Registos.FindAsync(id);
            _context.Registos.Remove(registo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistoExists(int id)
        {
            return _context.Registos.Any(e => e.Id == id);
        }
    }
}
