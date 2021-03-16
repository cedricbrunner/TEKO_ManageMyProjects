/*
 * Human Resource Class 
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
    public class PersonnelResource : BaseEntity
    {
        public string ResourceTitle { get; set; }
        public int? ResourcePlanned { get; set; }
        public int? ResourceReal { get; set; }
        public string? RessourceDeviation { get; set; }


        public int? FunctionId { get; set; }
        public Function Function { get; set; }

        public int? PhaseActivityId { get; set; }
        public PhasesActivity PhaseActivity { get; set; }


    }
}
