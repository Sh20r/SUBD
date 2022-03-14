﻿using System;
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
            List<Employee> employees = _context.Employees.ToList();
            List<FinishedProducts> finishedProducts = _context.FinishedProducts.ToList();
            SellsViewModel sellsViewModel = new SellsViewModel()
            {
                Employees = new SelectList(employees, "Id", "Surname"),
                FinProducts = new SelectList(finishedProducts, "Id", "Name"),
                errorText = ""
            };

            return View(sellsViewModel);
        }

        // POST: Sells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? emp, int? finprod, int? quan)
        {
            var budget = _context.Budgets.Where(u => u.Id == 1).FirstOrDefault();
            var fp = _context.FinishedProducts.Where(u => u.Id == finprod).FirstOrDefault();
            if(fp.Quantity > quan)
            {
                int prodPrice = fp.Sum / fp.Quantity;
                int finishedSum = prodPrice * (int)quan;
                int FinRate = finishedSum/100*budget.Rate;
                int FinishedSumWithRate = finishedSum + FinRate;

                Sell sell = new Sell();
                sell.Sum = FinishedSumWithRate;
                sell.Quantity = (int)quan;
                sell.FinishedProductsId = (int)finprod;
                sell.EmployeeId = (int)emp;
                _context.Add(sell);
                await _context.SaveChangesAsync();

                fp.Quantity -= (int)quan;
                fp.Sum -= finishedSum;

                await _context.SaveChangesAsync();

                budget.CountOfBudget += FinishedSumWithRate; ;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            List<Employee> employees = _context.Employees.ToList();
            List<FinishedProducts> finishedProducts = _context.FinishedProducts.ToList();
            SellsViewModel sellsViewModel = new SellsViewModel()
            {
                Employees = new SelectList(employees, "Id", "Surname"),
                FinProducts = new SelectList(finishedProducts, "Id", "Name"),
                SelectedEmp = emp,
                SelectedProd = finprod,
                Quantity = (int)quan,
                errorText = "Не хватает запасов!"
            };
            if (finprod.HasValue)
            {
                var itemToSelect = sellsViewModel.FinProducts.FirstOrDefault(x => x.Value == finprod.Value.ToString());
                itemToSelect.Selected = true;
            }
            if (emp.HasValue)
            {
                var itemToSelect = sellsViewModel.Employees.FirstOrDefault(x => x.Value == emp.Value.ToString());
                itemToSelect.Selected = true;
            }

            return View(sellsViewModel);
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
