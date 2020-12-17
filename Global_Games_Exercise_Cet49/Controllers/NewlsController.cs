using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Global_Games_Exercise_Cet49.Data;
using Global_Games_Exercise_Cet49.Data.Entities;

namespace Global_Games_Exercise_Cet49.Controllers
{
    public class NewlsController : Controller
    {
        private readonly DataContext _context;

        public NewlsController(DataContext context)
        {
            _context = context;
        }

        // GET: Newls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Newls.ToListAsync());
        }

        // GET: Newls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newl = await _context.Newls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newl == null)
            {
                return NotFound();
            }

            return View(newl);
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
                return RedirectToAction(nameof(Index));
            }
            return View(newl);
        }

        // GET: Newls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newl = await _context.Newls.FindAsync(id);
            if (newl == null)
            {
                return NotFound();
            }
            return View(newl);
        }

        // POST: Newls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mail")] Newl newl)
        {
            if (id != newl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewlExists(newl.Id))
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
            return View(newl);
        }

        // GET: Newls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newl = await _context.Newls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newl == null)
            {
                return NotFound();
            }

            return View(newl);
        }

        // POST: Newls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newl = await _context.Newls.FindAsync(id);
            _context.Newls.Remove(newl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewlExists(int id)
        {
            return _context.Newls.Any(e => e.Id == id);
        }
    }
}
