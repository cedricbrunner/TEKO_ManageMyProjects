using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManageMyProjects.Data;
using ManageMyProjects.Models;

namespace ManageMyProjects.Controllers
{
    public class ExternalCostsController : Controller
    {
        private readonly ManageMyProjectDbContext _context;

        public ExternalCostsController(ManageMyProjectDbContext context)
        {
            _context = context;
        }

        // GET: ExternalCosts
        public async Task<IActionResult> Index()
        {
            var manageMyProjectDbContext = _context.ExternalCosts.Include(e => e.PhaseActivity);
            return View(await manageMyProjectDbContext.ToListAsync());
        }

        // GET: ExternalCosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var externalCost = await _context.ExternalCosts
                .Include(e => e.PhaseActivity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (externalCost == null)
            {
                return NotFound();
            }

            return View(externalCost);
        }

        // GET: ExternalCosts/Create
        public IActionResult Create()
        {
            ViewData["PhaseActivityId"] = new SelectList(_context.PhasesActivities, "Id", "Id");
            return View();
        }

        // POST: ExternalCosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExternalCostTitle,ExternalCostTyp,ExternalCostAmountPlanned,ExternalCostAmountReal,PhaseActivityId,Id")] ExternalCost externalCost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(externalCost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhaseActivityId"] = new SelectList(_context.PhasesActivities, "Id", "Id", externalCost.PhaseActivityId);
            return View(externalCost);
        }

        // GET: ExternalCosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var externalCost = await _context.ExternalCosts.FindAsync(id);
            if (externalCost == null)
            {
                return NotFound();
            }
            ViewData["PhaseActivityId"] = new SelectList(_context.PhasesActivities, "Id", "Id", externalCost.PhaseActivityId);
            return View(externalCost);
        }

        // POST: ExternalCosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExternalCostTitle,ExternalCostTyp,ExternalCostAmountPlanned,ExternalCostAmountReal,PhaseActivityId,Id")] ExternalCost externalCost)
        {
            if (id != externalCost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(externalCost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExternalCostExists(externalCost.Id))
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
            ViewData["PhaseActivityId"] = new SelectList(_context.PhasesActivities, "Id", "Id", externalCost.PhaseActivityId);
            return View(externalCost);
        }

        // GET: ExternalCosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var externalCost = await _context.ExternalCosts
                .Include(e => e.PhaseActivity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (externalCost == null)
            {
                return NotFound();
            }

            return View(externalCost);
        }

        // POST: ExternalCosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var externalCost = await _context.ExternalCosts.FindAsync(id);
            _context.ExternalCosts.Remove(externalCost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExternalCostExists(int id)
        {
            return _context.ExternalCosts.Any(e => e.Id == id);
        }
    }
}
