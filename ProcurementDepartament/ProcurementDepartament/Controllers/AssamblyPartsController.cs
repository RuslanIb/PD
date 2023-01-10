using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcurementDepartament.Data;
using ProcurementDepartament.Models.Entities;

namespace ProcurementDepartament.Controllers
{
    public class AssamblyPartsController : Controller
    {
        private readonly ProcurementDepartamentContext _context;

        public AssamblyPartsController(ProcurementDepartamentContext context)
        {
            _context = context;
        }

        // GET: AssamblyParts
        public async Task<IActionResult> Index()
        {
              return View(await _context.AssamblyParts.ToListAsync());
        }

        // GET: AssamblyParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AssamblyParts == null)
            {
                return NotFound();
            }

            var assamblyPart = await _context.AssamblyParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assamblyPart == null)
            {
                return NotFound();
            }

            return View(assamblyPart);
        }

        // GET: AssamblyParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssamblyParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DronCategory,Description,Quantity")] AssamblyPart assamblyPart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assamblyPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assamblyPart);
        }

        // GET: AssamblyParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssamblyParts == null)
            {
                return NotFound();
            }

            var assamblyPart = await _context.AssamblyParts.FindAsync(id);
            if (assamblyPart == null)
            {
                return NotFound();
            }
            return View(assamblyPart);
        }

        // POST: AssamblyParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DronCategory,Description,Quantity")] AssamblyPart assamblyPart)
        {
            if (id != assamblyPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assamblyPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssamblyPartExists(assamblyPart.Id))
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
            return View(assamblyPart);
        }

        // GET: AssamblyParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssamblyParts == null)
            {
                return NotFound();
            }

            var assamblyPart = await _context.AssamblyParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assamblyPart == null)
            {
                return NotFound();
            }

            return View(assamblyPart);
        }

        // POST: AssamblyParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssamblyParts == null)
            {
                return Problem("Entity set 'ProcurementDepartamentContext.AssamblyParts'  is null.");
            }
            var assamblyPart = await _context.AssamblyParts.FindAsync(id);
            if (assamblyPart != null)
            {
                _context.AssamblyParts.Remove(assamblyPart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssamblyPartExists(int id)
        {
          return _context.AssamblyParts.Any(e => e.Id == id);
        }
    }
}
