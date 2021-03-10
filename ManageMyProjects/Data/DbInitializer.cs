using ManageMyProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageMyProjects.Data
{
    public static class DbInitializer
    {

        public static void Initialize(ManageMyProjectDbContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (!context.Departments.Any())
                {
                    var departments = new Department[]
                    {
                        new Department { DepartmentName = "Test Department" },
                    };
                    foreach (Department department in departments)
                    {
                        context.Departments.Add(department);
                    }

                }

                if (!context.ProcedureModels.Any())
                {
                    var proceduremodels = new ProcedureModel[]
                    {
                        new ProcedureModel { ProcedureModelName = "Hermes" },
                    };
                    foreach (ProcedureModel proceduremodel in proceduremodels)
                    {
                        context.ProcedureModels.Add(proceduremodel);
                    }
                }



                if (!context.Employees.Any())
                {
                    var employees = new Employee[]
                    {
                        new Employee {  EmployeeFirstName = "Hans", 
                                        EmployeeLastName = "Huber", 
                                        EmployeeNumber = 1000, 
                                        EmployeeWorkload = 80}

                    };
                    foreach (Employee employee in employees)
                    {
                        context.Employees.Add(employee);
                    }
                }


                if (!context.Functions.Any())
                {
                    var functions = new Function[]
                    {
                        new Function { FunctionTyp = "Zitronenfalter" }

                    };
                    foreach (Function function in functions)
                    {
                        context.Functions.Add(function);
                    }
                }

                if (!context.Projects.Any())
                {
                    var projects = new Project[]
                    {
                        new Project { ProjectTitle = "TestProject"}

                    };
                    foreach (Project project in projects)
                    {
                        context.Projects.Add(project);
                    }
                }

                if (!context.Priorities.Any())
                {
                    var prioritys = new Priority[]
                    {
                        new Priority { PriorityType = "Hoch"}

                    };
                    foreach (Priority priority in prioritys)
                    {
                        context.Priorities.Add(priority);
                    }
                }


                if (!context.PhasesActivities.Any())
                {
                    var phasesacivities = new PhasesActivity[]
                    {
                        new PhasesActivity { PhaseActivityName = "Implementation"}

                    };
                    foreach (PhasesActivity phasesactivity in phasesacivities)
                    {
                        context.PhasesActivities.Add(phasesactivity);
                    }
                }

                if (!context.Milestones.Any())
                {
                    var milestones = new Milestone[]
                    {
                        new Milestone { MilestoneName = "aaaatz"}

                    };
                    foreach (Milestone milestone in milestones)
                    {
                        context.Milestones.Add(milestone);
                    }
                }

                if (!context.Priorities.Any())
                {
                    var priorities = new Priority[]
                    {
                        new Priority { PriorityType = "Priority X"}

                    };
                    foreach (Priority priority in priorities)
                    {
                        context.Priorities.Add(priority);
                    }
                }


                context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception during DbInitializer: " + e.ToString());
            }
           
        }
    }
}
