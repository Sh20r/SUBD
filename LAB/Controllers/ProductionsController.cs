using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB.Models;
using LAB.ViewModels;

namespace LAB.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly LABAppContext _context;

        public ProductionsController(LABAppContext context)
        {
            _context = context;
        }

        // GET: Productions
        public async Task<IActionResult> Index()
        {
           return View(await _context.Productions.ToListAsync());
        }

        // GET: Productions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // GET: Productions/Create

        public IActionResult Create(int? selectedProd)
        {
            List<Employee> employees = _context.Employees.ToList();
            List<FinishedProducts> finishedProducts = _context.FinishedProducts.ToList();
            productionViewModel production = new productionViewModel
            {
                FinProduct = new SelectList(finishedProducts, "Id", "Name"),
                Employee = new SelectList(employees, "Id", "Surname"),
                ingredients = null

            };
            if (selectedProd != 0 || selectedProd != null)
            {
                if (selectedProd.HasValue)
                {
                    var itemToSelect = production.FinProduct.FirstOrDefault(x => x.Value == selectedProd.Value.ToString());
                    itemToSelect.Selected = true;
                }
            }
            return View(production);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int? selectedProd, int? selectedEmp, int? quan)
        {
            
            string text = CreateAccept(selectedProd, selectedEmp, quan);

            IEnumerable<Ingredients> ingredients_ = _context.Ingredients.Include(u => u.Raws).Include(k => k.FinishedProducts).Where(p => p.FinishedProductsId == selectedProd);
            List<Employee> employees = _context.Employees.ToList();
            List<FinishedProducts> finishedProducts = _context.FinishedProducts.ToList();
            productionViewModel production = new productionViewModel
            {
                FinProduct = new SelectList(finishedProducts, "Id", "Name"),
                Employee = new SelectList(employees, "Id", "Surname"),
                ingredients = ingredients_,
                selectedProd = selectedProd,
                selectedEmp = selectedEmp,
                Quantity = (int)quan,
                errorText = text             
            };
            if (selectedProd.HasValue)
            {
                var itemToSelect = production.FinProduct.FirstOrDefault(x => x.Value == selectedProd.Value.ToString());
                itemToSelect.Selected = true;
            }
            if (selectedEmp.HasValue)
            {
                var itemToSelect = production.Employee.FirstOrDefault(x => x.Value == selectedEmp.Value.ToString());
                itemToSelect.Selected = true;
            }
            return View(production);

        }
        public string CreateAccept(int? Quan, int? selectedProd, int? selectEmp)
        {
            
            List<Ingredients> ingredients_ = _context.Ingredients.Include(u => u.Raws).Include(k => k.FinishedProducts).Where(p => p.FinishedProductsId == selectedProd).ToList();
            List<Employee> employees = _context.Employees.ToList();
            List<FinishedProducts> finishedProducts = _context.FinishedProducts.ToList();
            List<Raw> raws = _context.Raws.ToList();
            for(int i = 0; i < ingredients_.Count();i++)
            {
                for(int j = 0; j < raws.Count(); j++)
                {
                    if(ingredients_[i].RawsId == raws[j].Id)
                    {
                        if (Quan*ingredients_[i].Quantity > raws[j].Quantity)
                        {
                            return "no";
                        }
                    }
                }
            }
            return "yes";
        }
        // POST: Productions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        

        // GET: Productions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions.FindAsync(id);
            if (production == null)
            {
                return NotFound();
            }
            return View(production);
        }

        // POST: Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Quantity")] Production production)
        {
            if (id != production.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(production);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionExists(production.Id))
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
            return View(production);
        }

        // GET: Productions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var production = await _context.Productions.FindAsync(id);
            _context.Productions.Remove(production);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionExists(int id)
        {
            return _context.Productions.Any(e => e.Id == id);
        }
    }
}
