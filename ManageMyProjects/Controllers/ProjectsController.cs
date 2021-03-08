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
    public class ProjectsController : Controller
    {
        private readonly ManageMyProjectDbContext _context;

        public ProjectsController(ManageMyProjectDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var manageMyProjectDbContext = _context.Projects.Include(p => p.Employee).Include(p => p.Priority).Include(p => p.ProcedureModel).Include(p => p.Status);
            return View(await manageMyProjectDbContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Employee)
                .Include(p => p.Priority)
                .Include(p => p.ProcedureModel)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeFirstName", "EmployeeFirstName");
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityType", "PriorityType");
            ViewData["ProcedureModelId"] = new SelectList(_context.ProcedureModels, "ProcedureModelName", "ProcedureModelName");
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusType", "StatusType");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectTitle,ProjectDescription,ProjectApprovalDate,ProjectStartDatePlanned,ProjectEndDatePlanned,ProjectStartDateRealized,ProjectEndDateRealized,ProjectProgress,EmployeeId,PriorityId,ProcedureModelId,StatusId,Id")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();

                ProcedureModel procedureModel = _context.ProcedureModels.ToList().Find(_procedureModel => _procedureModel.Id == project.ProcedureModelId);

                List<Phase> generatedPhases = new List<Phase>();
                if (procedureModel.ProcedureModelName == "Hermes")
                {
                    generatedPhases.AddRange(new List<Phase>() {
                        new Phase()
                        {
                            ProjectId = project.Id,
                            PhaseName = "Initialisierung",                            
                        },
                          new Phase()
                          {
                              ProjectId = project.Id,
                              PhaseName = "Konzept"                              
                          },
                            new Phase()
                            {
                                ProjectId = project.Id,
                                PhaseName = "Realisierung"                                
                            },
                            new Phase()
                            {
                                ProjectId = project.Id,
                                PhaseName = "Einführung"                    
                            }
                        }
                    );
                }



                if (procedureModel.ProcedureModelName == "V-Modell")
                {
                    generatedPhases.AddRange(new List<Phase>() {
                        new Phase()

                        {
                            ProjectId = project.Id,
                            PhaseName = "Systemanforderungsanalyse"                            
                        },
                          new Phase()
                          {
                              ProjectId = project.Id,
                              PhaseName = "System-Architektur und Entwurf"                            
                          },
                            new Phase()
                            {
                                ProjectId = project.Id,
                                PhaseName = "Software Architektur und EntwurfEntwurf"                               
                            },
                            new Phase()
                            {
                                ProjectId = project.Id,
                                PhaseName = "Unit und Integrations Test"                               
                            },
                            new Phase()
                            {
                                ProjectId = project.Id,
                                PhaseName = "System Integration"                               
                            },
                            new Phase()
                            {
                                ProjectId = project.Id,
                                PhaseName = "Abnahme und Nutzung"                               
                            }
                        }
                      );
                }

                if (procedureModel.ProcedureModelName == "Unified Process")
                {
                    generatedPhases.AddRange(new List<Phase>() {
                        new Phase()
                        {
                            ProjectId = project.Id,
                            PhaseName = "Inception"                           
                        },
                          new Phase()
                          {
                              ProjectId = project.Id,
                              PhaseName = "Elaboration"                            
                          },
                            new Phase()
                            {
                                ProjectId = project.Id,
                                PhaseName = "Construction"                               
                            },
                            new Phase()
                            {
                                ProjectId = project.Id,
                                PhaseName = "Transition"
                            }
                        }
                      );
                }

                if (generatedPhases.Count > 0)
                {
                    _context.AddRange(generatedPhases);
                    await _context.SaveChangesAsync();

                    try
                    {
                        List<Milestone> milestones = new List<Milestone>();
                        foreach (Phase currentPhase in generatedPhases)
                        {
                            milestones.Add(new Milestone()
                            {
                                PhaseId = currentPhase.Id,
                                ProjectId = project.Id,
                                MilestoneDate = DateTime.Now,
                                MilestoneName = "Initial Meilenstein - " + currentPhase.PhaseName
                            });

                            
                        }
                        _context.AddRange(milestones);
                        await _context.SaveChangesAsync();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Fehler2: " + e.ToString());
                    }
                   
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeFirstName", "EmployeeFirstName", project.EmployeeId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityType", "PriorityType", project.PriorityId);
            ViewData["ProcedureModelId"] = new SelectList(_context.ProcedureModels, "ProcedureModelName", "ProcedureModelName", project.ProcedureModelId);
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusType", "StatusType", project.StatusId);
            return View(project);
        }

           

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeFirstName", "EmployeeFirstName", project.EmployeeId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityType", "PriorityType", project.PriorityId);
            ViewData["ProcedureModelId"] = new SelectList(_context.ProcedureModels, "ProcedureModelName", "ProcedureModelName", project.ProcedureModelId);
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusType", "StatusType", project.StatusId);
            return View(project);
        }


      
        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectTitle,ProjectDescription,ProjectApprovalDate,ProjectStartDatePlanned,ProjectEndDatePlanned,ProjectStartDateRealized,ProjectEndDateRealized,ProjectProgress,EmployeeId,PriorityId,ProcedureModelId,StatusId,Id")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "EmployeeFirstName", project.EmployeeId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "PriorityType", project.PriorityId);
            ViewData["ProcedureModelId"] = new SelectList(_context.ProcedureModels, "Id", "ProcedureModelName", project.ProcedureModelId);
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "Id", "StatusType", project.StatusId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Employee)
                .Include(p => p.Priority)
                .Include(p => p.ProcedureModel)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
