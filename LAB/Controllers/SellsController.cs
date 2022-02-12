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
    public class SellsController : Controller
    {
        private readonly LABAppContext _context;

        public SellsController(LABAppContext context)
        {
            _context = context;
        }

        // GET: Sells
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sells.ToListAsync());
        }

        // GET: Sells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sells
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sell == null)
            {
                return NotFound();
            }

            return View(sell);
        }

        // GET: Sells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Quantity,Sum")] Sell sell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sell);
        }

        // GET: Sells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sells.FindAsync(id);
            if (sell == null)
            {
                return NotFound();
            }
            return View(sell);
        }

        // POST: Sells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Quantity,Sum")] Sell sell)
        {
            if (id != sell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellExists(sell.Id))
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
            return View(sell);
        }

        // GET: Sells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sells
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sell == null)
            {
                return NotFound();
            }

            return View(sell);
        }

        // POST: Sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sell = await _context.Sells.FindAsync(id);
            _context.Sells.Remove(sell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellExists(int id)
        {
            return _context.Sells.Any(e => e.Id == id);
        }
    }
}
