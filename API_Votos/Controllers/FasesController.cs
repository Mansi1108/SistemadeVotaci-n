using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Votos.Models;

namespace API_Votos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FasesController : ControllerBase
    {
        private readonly VotosContext _context;

        public FasesController()
        {
            _context = new();
        }

        // GET: api/Fases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fase>>> GetFases()
        {
          if (_context.Fases == null)
          {
              return NotFound();
          }
            return await _context.Fases.ToListAsync();
        }

        // GET: api/Fases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fase>> GetFase(string id)
        {
          if (_context.Fases == null)
          {
              return NotFound();
          }
            var fase = await _context.Fases.FindAsync(id);

            if (fase == null)
            {
                return NotFound();
            }

            return fase;
        }

        // PUT: api/Fases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFase(string id, Fase fase)
        {
            if (id != fase.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(fase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool FaseExists(string id)
        {
            return (_context.Fases?.Any(e => e.Nombre == id)).GetValueOrDefault();
        }
    }
}
