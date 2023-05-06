using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Votos.Models;
using modelsAux;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemadeVotación.Models;

namespace SistemadeVotación.Controllers
{
    public class CandidatosPresidencialesController : Controller
    {
        private readonly Services.APIServices _services = new();

        public CandidatosPresidencialesController()
        {
            _services.SetModule("CandidatosPresidenciales");
        }
        // GET: CandidatosPresidenciales
        public async Task<IActionResult> Index()
        {
            Models.VotosContext _context = new();
            bool active = (_context.Fases?.Any(e => e.Nombre == "crearCandidatos")).GetValueOrDefault();
            if (active)
            {
                var votos = await _services.Get<IEnumerable<Models.CandidatosPresidenciale>>();
                TempData["EstaActivo"] = "Si";
                return votos != null ? View(votos) : RedirectToAction("Index");

            }
            else
            {
                TempData["EstaActivo"] = null;
                return RedirectToAction("Index");
            }
            
        }


        // GET: CandidatosPresidenciales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CandidatosPresidenciales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,NoDpi,Edad,Nacionalidad,DepartamentoNacimiento,PartidoPolitico,FotoUrl,FechaIngresoPartido,FechaRegistro")]  Models.CandidatosPresidenciale candidatosPresidenciale)
        {
            await _services.Post(candidatosPresidenciale);
            return RedirectToAction(nameof(Index));
        }

        // GET: CandidatosPresidenciales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Models.VotosContext _context = new();
            if (id == null || _context.CandidatosPresidenciales == null)
            {
                return NotFound();
            }

            var candidatosPresidenciale = await _services.Get<Models.CandidatosPresidenciale>(id.ToString());
            if (candidatosPresidenciale == null)
            {
                return NotFound();
            }
            return View(candidatosPresidenciale);
        }

        // POST: CandidatosPresidenciales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,NoDpi,Edad,Nacionalidad,DepartamentoNacimiento,PartidoPolitico,FotoUrl,FechaIngresoPartido,FechaRegistro")] Models.CandidatosPresidenciale candidatosPresidenciale)
        {
            Models.VotosContext _context = new();
            if (id != candidatosPresidenciale.Id)
            {
                return NotFound();
            }
            var candidato = await _services.Put<Models.CandidatosPresidenciale>(candidatosPresidenciale, id.ToString());

            return RedirectToAction(nameof(Index));
        }

        // GET: CandidatosPresidenciales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Models.VotosContext _context = new();
            var candidatosPresidenciale = await _services.Get<Models.CandidatosPresidenciale>(id.ToString());

            if (candidatosPresidenciale == null)
            {
                return NotFound();
            }

            return View(candidatosPresidenciale);
        }

        // POST: CandidatosPresidenciales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _services.Delete(id.ToString());
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatosPresidencialeExists(int id)
        {
            Models.VotosContext _context = new();
            return (_context.CandidatosPresidenciales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
