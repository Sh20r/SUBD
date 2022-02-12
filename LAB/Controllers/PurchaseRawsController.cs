using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB.Models;

namespace LAB.Controllers
{
    public class PurchaseRawsController : Controller
    {
        private readonly LABAppContext _context;

        public PurchaseRawsController(LABAppContext context)
        {
            _context = context;
        }

        // GET: PurchaseRaws
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseRaws.ToListAsync());
        }

        // GET: PurchaseRaws/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRaw = await _context.PurchaseRaws
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseRaw == null)
            {
                return NotFound();
            }

            return View(purchaseRaw);
        }

        // GET: PurchaseRaws/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseRaws/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,Sum,Date")] PurchaseRaw purchaseRaw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseRaw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseRaw);
        }

        // GET: PurchaseRaws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRaw = await _context.PurchaseRaws.FindAsync(id);
            if (purchaseRaw == null)
            {
                return NotFound();
            }
            return View(purchaseRaw);
        }

        // POST: PurchaseRaws/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Sum,Date")] PurchaseRaw purchaseRaw)
        {
            if (id != purchaseRaw.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseRaw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseRawExists(purchaseRaw.Id))
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
            return View(purchaseRaw);
        }

        // GET: PurchaseRaws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseRaw = await _context.PurchaseRaws
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseRaw == null)
            {
                return NotFound();
            }

            return View(purchaseRaw);
        }

        // POST: PurchaseRaws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseRaw = await _context.PurchaseRaws.FindAsync(id);
            _context.PurchaseRaws.Remove(purchaseRaw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseRawExists(int id)
        {
            return _context.PurchaseRaws.Any(e => e.Id == id);
        }
    }
}
