using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using guiaUnivesitario.Models;

namespace guiaUnivesitario.Controllers
{
    public class UniversidadesController : Controller
    {
        private readonly AppDbContext _context;

        public UniversidadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Universidades
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Universidades.ToListAsync();

            return View(dados);
        }

        // GET: Universidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidade = await _context.Universidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (universidade == null)
            {
                return NotFound();
            }

            return View(universidade);
        }

        // GET: Universidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Universidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Cidade,Estado,Cep,Curso,avaliacaoMEC,avaliacaoAluno,avaliacaoProfessor,Comentario,Preco,Site")] Universidade universidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universidade);
        }

        // GET: Universidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidade = await _context.Universidades.FindAsync(id);
            if (universidade == null)
            {
                return NotFound();
            }
            return View(universidade);
        }

        // POST: Universidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Cidade,Estado,Cep,Curso,avaliacaoMEC,avaliacaoAluno,avaliacaoProfessor,Comentario,Preco,Site")] Universidade universidade)
        {
            if (id != universidade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversidadeExists(universidade.ID))
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
            return View(universidade);
        }

        // GET: Universidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidade = await _context.Universidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (universidade == null)
            {
                return NotFound();
            }

            return View(universidade);
        }

        // POST: Universidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universidade = await _context.Universidades.FindAsync(id);
            if (universidade != null)
            {
                _context.Universidades.Remove(universidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversidadeExists(int id)
        {
            return _context.Universidades.Any(e => e.ID == id);
        }
    }
}
