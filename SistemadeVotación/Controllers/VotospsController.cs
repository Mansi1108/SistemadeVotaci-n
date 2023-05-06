using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Votos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemadeVotación.Models;

namespace SistemadeVotación.Controllers
{
    public class VotospsController : Controller
    {
        private readonly Services.APIServices _services = new();

        public VotospsController()
        {
            _services.SetModule("Votosps");
        }

        // GET: Votosps
        public async Task<IActionResult> Index()
        {
            var votos = await _services.Get<IEnumerable<Models.Votosp>>();
            return votos != null ? View(votos) : RedirectToAction("Index");
        }

        // GET: Votosps/Create
        public IActionResult Create()
        {
            Models.VotosContext _context = new();
            ViewData["IdCandidato"] = new SelectList(_context.CandidatosPresidenciales, "Id", "NombreCompleto");
            return View();
        }

        // POST: Votosps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCandidato,NoDpi")] Models.Votosp votosp)
        {
            Models.VotosContext _context = new();
            bool existe = VotospExists(votosp.NoDpi);
            //bool active = (_context.Fases?.Any(e => e.Nombre == "votacion")).GetValueOrDefault();
            var fase = await _services.GetFase<Models.Fase>("votacion");
            int active2 = fase.Activo;
            if (!existe)
            {
                if (active2 == 1)
                {
                    await _services.Post(votosp);
                    ViewData["IdCandidato"] = new SelectList(_context.CandidatosPresidenciales, "Id", "NombreCompleto", votosp.IdCandidato);
                    return RedirectToAction("Index");
                } else
                {
                    TempData["EstaActivo"] = null;
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                TempData["ErrorMessage"] = "El voto de este dpi ya fue creado.";
                return RedirectToAction("Create");
            }
            
        }

        private bool VotospExists(string dpi)
        {
            Models.VotosContext _context = new();
            return (_context.Votosps?.Any(e => e.NoDpi == dpi)).GetValueOrDefault();
        }
    }
}
