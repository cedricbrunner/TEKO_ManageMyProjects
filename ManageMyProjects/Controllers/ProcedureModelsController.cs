/*
 * Procedure Model Controller 
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
    public class ProcedureModelsController : Controller
    {
        private readonly ManageMyProjectDbContext _context;

        public ProcedureModelsController(ManageMyProjectDbContext context)
        {
            _context = context;
        }

        // GET: ProcedureModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcedureModels.ToListAsync());
        }

        // GET: ProcedureModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedureModel = await _context.ProcedureModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedureModel == null)
            {
                return NotFound();
            }

            return View(procedureModel);
        }

        // GET: ProcedureModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcedureModels/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedureModelName,ProcedureModelName")] ProcedureModel procedureModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedureModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedureModel);
        }

        // GET: ProcedureModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedureModel = await _context.ProcedureModels.FindAsync(id);
            if (procedureModel == null)
            {
                return NotFound();
            }
            return View(procedureModel);
        }

        // POST: ProcedureModels/Edit/5
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcedureModelName,ProcedureModelName")] ProcedureModel procedureModel)
        {
            if (id != procedureModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedureModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureModelExists(procedureModel.Id))
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
            return View(procedureModel);
        }

        // GET: ProcedureModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedureModel = await _context.ProcedureModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedureModel == null)
            {
                return NotFound();
            }

            return View(procedureModel);
        }

        // POST: ProcedureModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedureModel = await _context.ProcedureModels.FindAsync(id);
            _context.ProcedureModels.Remove(procedureModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedureModelExists(int id)
        {
            return _context.ProcedureModels.Any(e => e.Id == id);
        }
    }
}
