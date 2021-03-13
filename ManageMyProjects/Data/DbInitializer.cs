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

                Department dep1 = new Department { DepartmentName = "Test Department" };
                Function func1 = new Function { FunctionTyp = "Zitronenfalter" };

                if (!context.Departments.Any())
                {
                   
                    var departments = new Department[]
                    {
                        dep1
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
                        func1

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
                        new Employee {  EmployeeFirstName = "Hans",
                                        EmployeeLastName = "Huber",
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
                        new Priority { PriorityType = "Hoch"}

                    };
                    foreach (Priority priority in prioritys)
                    {
                        context.Priorities.Add(priority);
                    
                    }
                    context.SaveChanges();
                }


                if (!context.Status.Any())
                {
                    var statuses = new Status[]
                    {
                        new Status { StatusType = "Test"}

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
