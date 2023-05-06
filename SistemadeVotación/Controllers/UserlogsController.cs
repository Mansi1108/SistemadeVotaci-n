using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemadeVotación.Models;

namespace SistemadeVotación.Controllers
{
    public class UserlogsController : Controller
    {
        private readonly VotosContext _context;

        public UserlogsController()
        {
            _context = new();
        }

        // GET: Userlogs
        public async Task<IActionResult> Index()
        {
              return _context.Userlogs != null ? 
                          View(await _context.Userlogs.ToListAsync()) :
                          Problem("Entity set 'VotosContext.Userlogs'  is null.");
        }

        // GET: Userlogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Userlogs == null)
            {
                return NotFound();
            }

            var userlog = await _context.Userlogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userlog == null)
            {
                return NotFound();
            }

            return View(userlog);
        }

        // GET: Userlogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Rol,Password")] Userlog userlog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userlog);
        }

        // GET: Userlogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Userlogs == null)
            {
                return NotFound();
            }

            var userlog = await _context.Userlogs.FindAsync(id);
            if (userlog == null)
            {
                return NotFound();
            }
            return View(userlog);
        }

        // POST: Userlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Rol,Password")] Userlog userlog)
        {
            if (id != userlog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserlogExists(userlog.Id))
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
            return View(userlog);
        }

        // GET: Userlogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Userlogs == null)
            {
                return NotFound();
            }

            var userlog = await _context.Userlogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userlog == null)
            {
                return NotFound();
            }

            return View(userlog);
        }

        // POST: Userlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Userlogs == null)
            {
                return Problem("Entity set 'VotosContext.Userlogs'  is null.");
            }
            var userlog = await _context.Userlogs.FindAsync(id);
            if (userlog != null)
            {
                _context.Userlogs.Remove(userlog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserlogExists(int id)
        {
          return (_context.Userlogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
