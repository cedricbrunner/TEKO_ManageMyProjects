/*
 * Personel Recources Controller 
 * 
 * C.Brunner
 * 03.2021
 */

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
    public class PersonnelResourcesController : Controller
    {
        private readonly ManageMyProjectDbContext _context;

        public PersonnelResourcesController(ManageMyProjectDbContext context)
        {
            _context = context;
        }

        // GET: PersonnelResources
        public async Task<IActionResult> Index()
        {
            var manageMyProjectDbContext = _context.PersonnelResources.Include(p => p.Function).Include(p => p.PhaseActivity);
            return View(await manageMyProjectDbContext.ToListAsync());
        }

        // GET: PersonnelResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelResource = await _context.PersonnelResources
                .Include(p => p.Function)
                .Include(p => p.PhaseActivity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnelResource == null)
            {
                return NotFound();
            }

            return View(personnelResource);
        }

        // GET: PersonnelResources/Create
        public IActionResult Create()
        {
            ViewData["FunctionId"] = new SelectList(_context.Functions, "Id", "FunctionTyp");
            ViewData["PhaseActivityId"] = new SelectList(_context.PhasesActivities, "Id", "PhaseActivityName");
            return View();
        }

        // POST: PersonnelResources/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourceTitle,ResourcePlanned,ResourceReal,RessourceDeviation,FunctionId,PhaseActivityId,Id")] PersonnelResource personnelResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personnelResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionId"] = new SelectList(_context.Functions, "Id", "FunctionTyp", personnelResource.FunctionId);
            ViewData["PhaseActivityId"] = new SelectList(_context.PhasesActivities, "Id", "PhaseActivityName", personnelResource.PhaseActivityId);
            return View(personnelResource);
        }

        // GET: PersonnelResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelResource = await _context.PersonnelResources.FindAsync(id);
            if (personnelResource == null)
            {
                return NotFound();
            }
            ViewData["FunctionId"] = new SelectList(_context.Functions, "Id", "FunctionTyp", personnelResource.FunctionId);
            ViewData["PhaseActivityId"] = new SelectList(_context.PhasesActivities, "Id", "PhaseActivityName", personnelResource.PhaseActivityId);
            return View(personnelResource);
        }

        // POST: PersonnelResources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourceTitle,ResourcePlanned,ResourceReal,RessourceDeviation,FunctionId,PhaseActivityId,Id")] PersonnelResource personnelResource)
        {
            if (id != personnelResource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnelResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnelResourceExists(personnelResource.Id))
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
            ViewData["FunctionId"] = new SelectList(_context.Functions, "Id", "FunctionTyp", personnelResource.FunctionId);
            ViewData["PhaseActivityId"] = new SelectList(_context.PhasesActivities, "Id", "PhaseActivityName", personnelResource.PhaseActivityId);
            return View(personnelResource);
        }

        // GET: PersonnelResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelResource = await _context.PersonnelResources
                .Include(p => p.Function)
                .Include(p => p.PhaseActivity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnelResource == null)
            {
                return NotFound();
            }

            return View(personnelResource);
        }

        // POST: PersonnelResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personnelResource = await _context.PersonnelResources.FindAsync(id);
            _context.PersonnelResources.Remove(personnelResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonnelResourceExists(int id)
        {
            return _context.PersonnelResources.Any(e => e.Id == id);
        }
    }
}
