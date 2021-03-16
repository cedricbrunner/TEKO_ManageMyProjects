/*
 * Employee Class 
 * 
 * C.Brunner
 * 03.2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageMyProjects.Models
{
    public class Employee : BaseEntity
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int EmployeeNumber { get; set; }
        public int EmployeeWorkload { get; set; }

        public int FunctionId { get; set; }
        public Function Function { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
