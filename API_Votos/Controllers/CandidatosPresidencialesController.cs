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
    public class CandidatosPresidencialesController : ControllerBase
    {

        // GET: api/CandidatosPresidenciales
        [HttpGet]
        public async Task<IEnumerable<modelsAux.CandidatosAux>> GetCandidatosPresidenciales()
        {
            VotosContext _context = new();
            IEnumerable<modelsAux.CandidatosAux> candidatos = _context.CandidatosPresidenciales.Select(x => new modelsAux.CandidatosAux
            {
                Id = x.Id,
                NombreCompleto= x.NombreCompleto,
                NoDpi= x.NoDpi,
                Edad= x.Edad,
                Nacionalidad= x.Nacionalidad,
                DepartamentoNacimiento=x.DepartamentoNacimiento,
                PartidoPolitico= x.PartidoPolitico,
                FotoUrl= x.FotoUrl,
                FechaIngresoPartido= x.FechaIngresoPartido,
            }).ToList();
            return candidatos;
        }

        // GET: api/CandidatosPresidenciales/5
        [HttpGet("{id}")]
        public async Task<modelsAux.CandidatosAux> GetCandidatosPresidenciale(int id)
        {
            VotosContext _context = new();
            modelsAux.CandidatosAux candidatosPresidenciale = _context.CandidatosPresidenciales.Select(x => new modelsAux.CandidatosAux
            {
                Id = x.Id,
                NombreCompleto = x.NombreCompleto,
                NoDpi = x.NoDpi,
                Edad = x.Edad,
                Nacionalidad = x.Nacionalidad,
                DepartamentoNacimiento = x.DepartamentoNacimiento,
                PartidoPolitico = x.PartidoPolitico,
                FotoUrl = x.FotoUrl,
                FechaIngresoPartido = x.FechaIngresoPartido,
            }).FirstOrDefault(x => x.Id == id);

            return candidatosPresidenciale;
        }

        // PUT: api/CandidatosPresidenciales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async void PutCandidatosPresidenciale(int id, modelsAux.CandidatosAuxM candidato)
        {
            VotosContext _context = new();
            CandidatosPresidenciale candidato1 = new CandidatosPresidenciale
            {
                Id = id,
                NombreCompleto = candidato.NombreCompleto,
                NoDpi = candidato.NoDpi,
                Edad = candidato.Edad,
                Nacionalidad = candidato.Nacionalidad,
                DepartamentoNacimiento = candidato.DepartamentoNacimiento,
                PartidoPolitico = candidato.PartidoPolitico,
                FotoUrl = candidato.FotoUrl,
                FechaIngresoPartido = candidato.FechaIngresoPartido,
                FechaRegistro = DateTime.Now,
            };
            _context.Update(candidato1);
            await _context.SaveChangesAsync();
        }

        // POST: api/CandidatosPresidenciales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CandidatosPresidenciale> PostCandidatosPresidenciale(modelsAux.CandidatosAuxM candidato)
        {
            VotosContext _context = new();
            CandidatosPresidenciale candidato1 = new CandidatosPresidenciale
            {
                NombreCompleto = candidato.NombreCompleto,
                NoDpi = candidato.NoDpi,
                Edad = candidato.Edad,
                Nacionalidad = candidato.Nacionalidad,
                DepartamentoNacimiento = candidato.DepartamentoNacimiento,
                PartidoPolitico = candidato.PartidoPolitico,
                FotoUrl = candidato.FotoUrl,
                FechaIngresoPartido = candidato.FechaIngresoPartido,
                FechaRegistro = DateTime.Now
            };
            _context.Add(candidato1);
            await _context.SaveChangesAsync();
            return candidato1;
        }

        // DELETE: api/CandidatosPresidenciales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidatosPresidenciale(int id)
        {
            VotosContext _context = new();
            if (_context.CandidatosPresidenciales == null)
            {
                return NotFound();
            }
            var candidatosPresidenciale = await _context.CandidatosPresidenciales.FindAsync(id);
            if (candidatosPresidenciale == null)
            {
                return NotFound();
            }

            _context.CandidatosPresidenciales.Remove(candidatosPresidenciale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatosPresidencialeExists(int id)
        {
            VotosContext _context = new();
            return (_context.CandidatosPresidenciales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
