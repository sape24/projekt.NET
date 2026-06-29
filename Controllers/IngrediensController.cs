using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using projekt.NET.Data;
using projekt.NET.Models;

namespace projekt.NET.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IngrediensController : Controller
    {
        private readonly AppDbContext _context;

        public IngrediensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ingrediens
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Ingrediens.Include(i => i.Recept);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Ingrediens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediens = await _context.Ingrediens
                .Include(i => i.Recept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingrediens == null)
            {
                return NotFound();
            }

            return View(ingrediens);
        }

        // GET: Ingrediens/Create
        public IActionResult Create()
        {
            ViewData["ReceptId"] = new SelectList(_context.Recept, "Id", "Titel");
            return View();
        }

        // POST: Ingrediens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namn,Mängd,Enhet,ReceptId")] Ingrediens ingrediens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingrediens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceptId"] = new SelectList(_context.Recept, "Id", "Titel", ingrediens.ReceptId);
            return View(ingrediens);
        }

        // GET: Ingrediens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediens = await _context.Ingrediens.FindAsync(id);
            if (ingrediens == null)
            {
                return NotFound();
            }
            ViewData["ReceptId"] = new SelectList(_context.Recept, "Id", "Titel", ingrediens.ReceptId);
            return View(ingrediens);
        }

        // POST: Ingrediens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namn,Mängd,Enhet,ReceptId")] Ingrediens ingrediens)
        {
            if (id != ingrediens.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingrediens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngrediensExists(ingrediens.Id))
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
            ViewData["ReceptId"] = new SelectList(_context.Recept, "Id", "Titel", ingrediens.ReceptId);
            return View(ingrediens);
        }

        // GET: Ingrediens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediens = await _context.Ingrediens
                .Include(i => i.Recept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingrediens == null)
            {
                return NotFound();
            }

            return View(ingrediens);
        }

        // POST: Ingrediens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingrediens = await _context.Ingrediens.FindAsync(id);
            if (ingrediens != null)
            {
                _context.Ingrediens.Remove(ingrediens);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngrediensExists(int id)
        {
            return _context.Ingrediens.Any(e => e.Id == id);
        }
    }
}
