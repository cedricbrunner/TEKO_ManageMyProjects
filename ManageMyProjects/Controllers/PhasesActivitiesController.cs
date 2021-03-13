using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManageMyProjects.Data;
using ManageMyProjects.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ManageMyProjects.Controllers
{
    public class PhasesActivitiesController : Controller
    {
        private readonly ManageMyProjectDbContext _context;

        public PhasesActivitiesController(ManageMyProjectDbContext context)
        {
            _context = context;
        }

        // GET: PhasesActivities
        public async Task<IActionResult> Index()
        {
            var manageMyProjectDbContext = _context.PhasesActivities.Include(p => p.Employee).Include(p => p.Phase).Include(p => p.Project).Include(p => p.Status);
            return View(await manageMyProjectDbContext.ToListAsync());
        }

        // GET: PhasesActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phasesActivity = await _context.PhasesActivities
                .Include(p => p.Employee)
                .Include(p => p.Phase)
                .Include(p => p.Project)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phasesActivity == null)
            {
                return NotFound();
            }

            return View(phasesActivity);
        }

        // GET: PhasesActivities/Create
        public IActionResult Create()
        {
            //ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            //ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "Id");
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id");
            //ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "EmployeeFirstName");
            ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "PhaseName");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusType");
            return View();
        }

        // POST: PhasesActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile FileContent, [Bind("PhaseActivityName,PhaseActivityProgress,Budget,RealCosts,Expense,PhaseActivityStartDatePlanned,PhaseActivityEndDatePlanned,PhaseActivityStartDateRealized,PhaseActivityEndDateRealized,EmployeeId,PhaseId,StatusId,ProjectId,Id")] PhasesActivity phasesActivity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    byte[] fileData = null;

                    // read file to byte array
                    using (var binaryReader = new BinaryReader(FileContent.OpenReadStream()))
                    {
                        fileData = binaryReader.ReadBytes((int)FileContent.Length);
                    }
                    phasesActivity.FileContent = fileData;

                }
                catch (Exception e)
                {
                    Console.WriteLine("test");
                }
                _context.Add(phasesActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "EmployeeFirstName", phasesActivity.EmployeeId);
            ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "PhaseName", phasesActivity.PhaseId);
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", phasesActivity.ProjectId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusType", phasesActivity.StatusId);
            return View(phasesActivity);
        }

        // GET: PhasesActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phasesActivity = await _context.PhasesActivities.FindAsync(id);
            if (phasesActivity == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "EmployeeFirstName", phasesActivity.EmployeeId);
            ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "PhaseName", phasesActivity.PhaseId);
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", phasesActivity.ProjectId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusType", phasesActivity.StatusId);
            return View(phasesActivity);
        }

        // POST: PhasesActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhaseActivityName,PhaseActivityProgress,Budget,RealCosts,Expense,PhaseActivityStartDatePlanned,PhaseActivityEndDatePlanned,PhaseActivityStartDateRealized,PhaseActivityEndDateRealized,EmployeeId,PhaseId,StatusId,ProjectId,FileContent,Id")] PhasesActivity phasesActivity)
        {
            if (id != phasesActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phasesActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhasesActivityExists(phasesActivity.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "EmployeeFirstName", phasesActivity.EmployeeId);
            ViewData["PhaseId"] = new SelectList(_context.Phases, "Id", "PhaseName", phasesActivity.PhaseId);
            // ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectTitle", phasesActivity.ProjectId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusType", phasesActivity.StatusId);
            return View(phasesActivity);
        }

        // GET: PhasesActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phasesActivity = await _context.PhasesActivities
                .Include(p => p.Employee)
                .Include(p => p.Phase)
                .Include(p => p.Project)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phasesActivity == null)
            {
                return NotFound();
            }

            return View(phasesActivity);
        }

        // POST: PhasesActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phasesActivity = await _context.PhasesActivities.FindAsync(id);
            _context.PhasesActivities.Remove(phasesActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhasesActivityExists(int id)
        {
            return _context.PhasesActivities.Any(e => e.Id == id);
        }
    }
}
