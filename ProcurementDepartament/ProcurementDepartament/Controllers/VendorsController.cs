using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcurementDepartament.Data;
using ProcurementDepartament.Models.Entities;

namespace ProcurementDepartament.Controllers
{
    public class VendorsController : Controller
    {
        private readonly ProcurementDepartamentContext _context;

        public VendorsController(ProcurementDepartamentContext context)
        {
            _context = context;
        }

        // GET: Vendors
        public async Task<IActionResult> Index()
        {
              return View(await _context.Vendors.ToListAsync());
        }

        // GET: Vendors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendors == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // GET: Vendors/Create        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Adress")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        [HttpGet]
        public IActionResult CreateOverExcel()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateOverExcel(List<Vendor> vendors)
        //{
        //    foreach (var vendor in vendors)
        //    {
        //        var vend = new Vendor();
        //        vend.Name = vendor.Name;
        //        vend.Phone = vendor.Phone;
        //        _context.Add(vend);
        //        await _context.SaveChangesAsync();
        //    }
        //    return View();
        //}

        // GET: Vendors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendors == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone")] Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.Id))
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
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendors == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendors == null)
            {
                return Problem("Entity set 'ProcurementDepartamentContext.Vendor'  is null.");
            }
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(int id)
        {
          return _context.Vendors.Any(e => e.Id == id);
        }
    }
}
