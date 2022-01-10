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
    public class InicialController : Controller
    {
        private readonly InicialContext _context;

        public InicialController(InicialContext context)
        {
            _context = context;
        }

        // GET: Inicial
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inicials.ToListAsync());
        }

        // GET: Inicial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicial = await _context.Inicials
                .FirstOrDefaultAsync(m => m.Id_Inicial == id);
            if (inicial == null)
            {
                return NotFound();
            }

            return View(inicial);
        }

        // GET: Inicial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inicial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Inicial,Buscar")] Inicial inicial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inicial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inicial);
        }

        // GET: Inicial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicial = await _context.Inicials.FindAsync(id);
            if (inicial == null)
            {
                return NotFound();
            }
            return View(inicial);
        }

        // POST: Inicial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Inicial,Buscar")] Inicial inicial)
        {
            if (id != inicial.Id_Inicial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inicial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InicialExists(inicial.Id_Inicial))
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
            return View(inicial);
        }

        // GET: Inicial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicial = await _context.Inicials
                .FirstOrDefaultAsync(m => m.Id_Inicial == id);
            if (inicial == null)
            {
                return NotFound();
            }

            return View(inicial);
        }

        // POST: Inicial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inicial = await _context.Inicials.FindAsync(id);
            _context.Inicials.Remove(inicial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InicialExists(int id)
        {
            return _context.Inicials.Any(e => e.Id_Inicial == id);
        }
    }
}
