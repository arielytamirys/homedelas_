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
    public class Cadastro_VagaController : Controller
    {
        private readonly InicialContext _context;

        public Cadastro_VagaController(InicialContext context)
        {
            _context = context;
        }

        // GET: Cadastro_Vaga
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cadastro_Vagas.ToListAsync());
        }

        // GET: Cadastro_Vaga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro_Vaga = await _context.Cadastro_Vagas
                .FirstOrDefaultAsync(m => m.Id_Cadastro_Vaga == id);
            if (cadastro_Vaga == null)
            {
                return NotFound();
            }

            return View(cadastro_Vaga);
        }

        // GET: Cadastro_Vaga/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastro_Vaga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Cadastro_Vaga,CNPJ,Empresa,Responsavel,Setor,Vaga,Descricao")] Cadastro_Vaga cadastro_Vaga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro_Vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro_Vaga);
        }

        // GET: Cadastro_Vaga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro_Vaga = await _context.Cadastro_Vagas.FindAsync(id);
            if (cadastro_Vaga == null)
            {
                return NotFound();
            }
            return View(cadastro_Vaga);
        }

        // POST: Cadastro_Vaga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Cadastro_Vaga,CNPJ,Empresa,Responsavel,Setor,Vaga,Descricao")] Cadastro_Vaga cadastro_Vaga)
        {
            if (id != cadastro_Vaga.Id_Cadastro_Vaga)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro_Vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cadastro_VagaExists(cadastro_Vaga.Id_Cadastro_Vaga))
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
            return View(cadastro_Vaga);
        }

        // GET: Cadastro_Vaga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro_Vaga = await _context.Cadastro_Vagas
                .FirstOrDefaultAsync(m => m.Id_Cadastro_Vaga == id);
            if (cadastro_Vaga == null)
            {
                return NotFound();
            }

            return View(cadastro_Vaga);
        }

        // POST: Cadastro_Vaga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastro_Vaga = await _context.Cadastro_Vagas.FindAsync(id);
            _context.Cadastro_Vagas.Remove(cadastro_Vaga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cadastro_VagaExists(int id)
        {
            return _context.Cadastro_Vagas.Any(e => e.Id_Cadastro_Vaga == id);
        }
    }
}
