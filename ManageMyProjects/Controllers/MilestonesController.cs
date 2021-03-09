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
    public class MilestonesController : Controller
    {
        private readonly ManageMyProjectDbContext _context;

        public MilestonesController(ManageMyProjectDbContext context)
        {
            _context = context;
        }

        // GET: Milestones
        public async Task<IActionResult> Index()
        {
            var manageMyProjectDbContext = _context.Milestones.Include(m => m.Phase).Include(m => m.Project);
            return View(await manageMyProjectDbContext.ToListAsync());
        }

        // GET: Milestones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestones
                .Include(m => m.Phase)
                .Include(m => m.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milestone == null)
            {
                return NotFound();
            }

            return View(milestone);
        }

        // GET: Milestones/Create
        public IActionResult Create()
        {
            ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "PhaseName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle");
            return View();
        }

        // POST: Milestones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MilestoneName,MilestoneDate,ProjectId,PhaseId,Id")] Milestone milestone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(milestone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "PhaseName", milestone.PhaseId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", milestone.ProjectId);
            return View(milestone);
        }

        // GET: Milestones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestones.FindAsync(id);
            if (milestone == null)
            {
                return NotFound();
            }
            ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "PhaseName", milestone.PhaseId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", milestone.ProjectId);
            return View(milestone);
        }

        // POST: Milestones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MilestoneName,MilestoneDate,ProjectId,PhaseId,Id")] Milestone milestone)
        {
            if (id != milestone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(milestone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilestoneExists(milestone.Id))
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
            ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "PhaseName", milestone.PhaseId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", milestone.ProjectId);
            return View(milestone);
        }

        // GET: Milestones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestones
                .Include(m => m.Phase)
                .Include(m => m.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milestone == null)
            {
                return NotFound();
            }

            return View(milestone);
        }

        // POST: Milestones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var milestone = await _context.Milestones.FindAsync(id);
            _context.Milestones.Remove(milestone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilestoneExists(int id)
        {
            return _context.Milestones.Any(e => e.Id == id);
        }
    }
}
