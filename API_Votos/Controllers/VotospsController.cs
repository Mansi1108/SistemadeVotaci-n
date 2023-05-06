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
    public class VotospsController : ControllerBase
    {

        // GET: api/Votosps
        [HttpGet]
        public async Task<IEnumerable<modelsAux.votosAux>> GetVotosps()
        {
            VotosContext _context = new();
            IEnumerable<modelsAux.votosAux> votos = _context.Votosps.Select(x => new modelsAux.votosAux
            {
                Id= x.Id,
                IdCandidato = x.IdCandidato,
                NoDpi= x.NoDpi
            }).ToList();
            foreach (var voto in votos)
            {
                CandidatosPresidenciale candidato = _context.CandidatosPresidenciales.Find(voto.Id);
                voto.IdCandidatoNavigation = new modelsAux.CandidatosAux
                {
                    NombreCompleto= candidato.NombreCompleto,
                    PartidoPolitico=candidato.PartidoPolitico,
                };
            }
            return votos;
        }

        // GET: api/Votosps/5
        [HttpGet("{id}")]
        public async Task<modelsAux.votosAux> GetVotosp(int id)
        {
            VotosContext _context = new();
            modelsAux.votosAux votos = _context.Votosps.Select(x => new modelsAux.votosAux
            {
                Id = x.Id,
                IdCandidato = x.IdCandidato,
                NoDpi = x.NoDpi,
            }).FirstOrDefault(x => x.Id == id);
            CandidatosPresidenciale candidato = _context.CandidatosPresidenciales.Find(votos.Id);
            votos.IdCandidatoNavigation = new modelsAux.CandidatosAux
            {
                NombreCompleto = candidato.NombreCompleto
            };

            return votos;
        }

        // POST: api/Votosps
        [HttpPost]
        public async Task<Votosp> PostVotosp(modelsAux.votosAuxM votosp)
        {
            VotosContext _context = new();
        
            Votosp votos = new Votosp
            {
                IdCandidato = votosp.IdCandidato,
                NoDpi = votosp.NoDpi,
            };
            _context.Add(votos);
            await _context.SaveChangesAsync();
            return votos;
            
        }

        private bool VotospExists(string dpi)
        {
            VotosContext _context = new();
            return (_context.Votosps?.Any(e => e.NoDpi == dpi)).GetValueOrDefault();
        }
    }
}
