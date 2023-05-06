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

        // POST: api/Fases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fase>> PostFase(Fase fase)
        {
          if (_context.Fases == null)
          {
              return Problem("Entity set 'VotosContext.Fases'  is null.");
          }
            _context.Fases.Add(fase);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FaseExists(fase.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFase", new { id = fase.Nombre }, fase);
        }


        private bool FaseExists(string id)
        {
            return (_context.Fases?.Any(e => e.Nombre == id)).GetValueOrDefault();
        }
    }
}
