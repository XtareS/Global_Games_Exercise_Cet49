
namespace Global_Games_Exercise_Cet49.Controllers
{
    using Global_Games_Exercise_Cet49.Data;
    using Global_Games_Exercise_Cet49.Data.Entities;
    using Global_Games_Exercise_Cet49.Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserLogsController : Controller
    {
        private readonly DataContext _context;
        private readonly IUxerHelper uxerHelper;

        public UserLogsController(DataContext context, IUxerHelper uxerHelper)
        {
            _context = context;
            this.uxerHelper = uxerHelper;
        }

        // GET: UserLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserLogs.ToListAsync());
        }

        // GET: UserLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLog = await _context.UserLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLog == null)
            {
                return NotFound();
            }

            return View(userLog);
        }

        // GET: UserLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageUrl")] UserLog userLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLog);
        }

        // GET: UserLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLog = await _context.UserLogs.FindAsync(id);
            if (userLog == null)
            {
                return NotFound();
            }
            return View(userLog);
        }

        // POST: UserLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageUrl")] UserLog userLog)
        {
            if (id != userLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLogExists(userLog.Id))
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
            return View(userLog);
        }

        // GET: UserLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLog = await _context.UserLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLog == null)
            {
                return NotFound();
            }

            return View(userLog);
        }

        // POST: UserLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userLog = await _context.UserLogs.FindAsync(id);
            _context.UserLogs.Remove(userLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLogExists(int id)
        {
            return _context.UserLogs.Any(e => e.Id == id);
        }
    }
}
