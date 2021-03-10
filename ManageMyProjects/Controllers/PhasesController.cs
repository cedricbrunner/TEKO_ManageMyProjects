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
    public class PhasesController : Controller
    {
        private readonly ManageMyProjectDbContext _context;

        public PhasesController(ManageMyProjectDbContext context)
        {
            _context = context;
        }

        // GET: Phases
        public async Task<IActionResult> Index()
        {
            var manageMyProjectDbContext = _context.Phases.Include(p => p.Project).Include(p => p.Status);
            return View(await manageMyProjectDbContext.ToListAsync());

        }



        // GET: Phases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases
                .Include(p => p.Project)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // GET: Phases/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusType");
            return View();
        }

        // POST: Phases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhaseName,PhaseReview,PhaseStartDatePlanned,PhaseEndDatePlanned,PhaseStartDateRealized,PhaseEndDateRealized,PhaseProgress,ProjectId,StatusId,Id")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", phase.ProjectId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusType", phase.StatusId);
            return View(phase);
        }

        // GET: Phases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", phase.ProjectId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusType", phase.StatusId);
            return View(phase);
        }

        // POST: Phases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhaseName,PhaseReview,PhaseStartDatePlanned,PhaseEndDatePlanned,PhaseStartDateRealized,PhaseEndDateRealized,PhaseProgress,ProjectId,StatusId,Id")] Phase phase)
        {
            if (id != phase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhaseExists(phase.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", phase.ProjectId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusType", phase.StatusId);
            return View(phase);
        }

        // GET: Phases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases
                .Include(p => p.Project)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // POST: Phases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phase = await _context.Phases.FindAsync(id);
            _context.Phases.Remove(phase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhaseExists(int id)
        {
            return _context.Phases.Any(e => e.Id == id);
        }
    }
}
