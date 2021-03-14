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

                Department dep1 = new Department { DepartmentName = "Project Management" };
                
              

                Function func1 = new Function { FunctionTyp = "Project Manager" };


                if (!context.Departments.Any())
                {
                   
                    var departments = new Department[]
                    {
                        dep1,
                        new Department { DepartmentName = "Concept & Design" },
                        new Department { DepartmentName = "Development" },
                        new Department { DepartmentName = "Marketing & Sales" },
                        new Department { DepartmentName = "Finance & Administration" },
                        new Department { DepartmentName = "Testing" }


                };
                    foreach (Department department in departments)
                    {
                        context.Departments.Add(department);
                    }

                }


                if (!context.Functions.Any())
                {
                    var functions = new Function[]
                    {
                        func1,

                    new Function { FunctionTyp = "Chef de cuisine" },
                    new Function { FunctionTyp = "Developper" },
                    new Function { FunctionTyp = "CEO" },
                    new Function { FunctionTyp = "Tester" },
                    new Function { FunctionTyp = "Project Employee" }


                    };
                    foreach (Function function in functions)
                    {
                        context.Functions.Add(function);
                    }
                }

                if (!context.Employees.Any())
                {
                    var employees = new Employee[]
                    {
                        new Employee {  EmployeeFirstName = "Max",
                                        EmployeeLastName = "Mustermann",
                                        EmployeeNumber = 1000,
                                        EmployeeWorkload = 80,
                                        Department = dep1,
                                        Function = func1
                        }

                    };
                    foreach (Employee employee in employees)
                    {
                        context.Employees.Add(employee);
                    }
                    context.SaveChanges();
                }

                if (!context.ProcedureModels.Any())
                {
                    var proceduremodels = new ProcedureModel[]
                    {
                        new ProcedureModel { ProcedureModelName = "Hermes" },
                        new ProcedureModel { ProcedureModelName = "V-Modell" },
                    };
                    foreach (ProcedureModel proceduremodel in proceduremodels)
                    {
                        context.ProcedureModels.Add(proceduremodel);
                    }
                    context.SaveChanges();
                }

                if (!context.Priorities.Any())
                {
                    var prioritys = new Priority[]
                    {
                        new Priority { PriorityType = "Priority 1"},
                        new Priority { PriorityType = "Priority 2"},
                        new Priority { PriorityType = "Priority 3"}
        
                    };
                    foreach (Priority priority in prioritys)
                    {
                        context.Priorities.Add(priority);
                    
                    }
                    context.SaveChanges();
                }

                if (!context.Costs.Any())
                {
                    var costs = new Cost[]
                    {
                        new Cost { CostTyp = "Software"},
                        new Cost { CostTyp = "Hardware"},
                        new Cost { CostTyp = "Service"}

                    };
                    foreach (Cost cost in costs)
                    {
                        context.Costs.Add(cost);

                    }
                    context.SaveChanges();
                }


                if (!context.Status.Any())
                {
                    var statuses = new Status[]
                    {
                        new Status { StatusType = "not launched"},
                        new Status { StatusType = "in progress"},
                        new Status { StatusType = "on hold"},
                        new Status { StatusType = "completed"},
                        new Status { StatusType = "canceled"},


                    };
                    foreach (Status status in statuses)
                    {
                        context.Status.Add(status);
                    }
                    context.SaveChanges();
                }

                
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception during DbInitializer: " + e.ToString());
            }
           
        }
    }
}
