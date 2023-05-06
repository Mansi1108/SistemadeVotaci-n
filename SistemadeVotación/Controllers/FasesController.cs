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
    public class FasesController : Controller
    {
        private readonly VotosContext _context;

        public FasesController(VotosContext context)
        {
            _context = context;
        }

        // GET: Fases
        public async Task<IActionResult> Index()
        {
              return _context.Fases != null ? 
                          View(await _context.Fases.ToListAsync()) :
                          Problem("Entity set 'VotosContext.Fases'  is null.");
        }

        // GET: Fases/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Fases == null)
            {
                return NotFound();
            }

            var fase = await _context.Fases
                .FirstOrDefaultAsync(m => m.Nombre == id);
            if (fase == null)
            {
                return NotFound();
            }

            return View(fase);
        }

        // GET: Fases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Activo")] Fase fase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fase);
        }

        // GET: Fases/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Fases == null)
            {
                return NotFound();
            }

            var fase = await _context.Fases.FindAsync(id);
            if (fase == null)
            {
                return NotFound();
            }
            return View(fase);
        }

        // POST: Fases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nombre,Activo")] Fase fase)
        {
            if (id != fase.Nombre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaseExists(fase.Nombre))
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
            return View(fase);
        }

       

        private bool FaseExists(string id)
        {
          return (_context.Fases?.Any(e => e.Nombre == id)).GetValueOrDefault();
        }
    }
}
