using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homedelas.Data;
using Homedelas.Models;

namespace Homedelas.Models.Controllers
{
    public class VagaController : Controller
    {
        private readonly InicialContext _context;

        public VagaController(InicialContext context)
        {
            _context = context;
        }

        // GET: Vaga
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vagas.ToListAsync());
        }

        // GET: Vaga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas
                .FirstOrDefaultAsync(m => m.Id_Vagas == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // GET: Vaga/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Vagas")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaga);
        }

        // GET: Vaga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }
            return View(vaga);
        }

        // POST: Vaga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Vagas")] Vaga vaga)
        {
            if (id != vaga.Id_Vagas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaExists(vaga.Id_Vagas))
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
            return View(vaga);
        }

        // GET: Vaga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas
                .FirstOrDefaultAsync(m => m.Id_Vagas == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // POST: Vaga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            _context.Vagas.Remove(vaga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaExists(int id)
        {
            return _context.Vagas.Any(e => e.Id_Vagas == id);
        }
    }
}
