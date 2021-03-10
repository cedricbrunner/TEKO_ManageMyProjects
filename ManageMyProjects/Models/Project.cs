using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageMyProjects.Models
{
    public class Project : BaseEntity
    {
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectApprovalDate { get; set; }
        public DateTime ProjectStartDatePlanned { get; set; }
        public DateTime ProjectEndDatePlanned { get; set; }
        public DateTime? ProjectStartDateRealized { get; set; }
        public DateTime? ProjectEndDateRealized { get; set; }
        public int ProjectProgress { get; set; }


        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int? ProcedureModelId { get; set; }
        public ProcedureModel ProcedureModel { get; set; }

        public int? StatusId { get; set; }
        public Status Status { get; set; }

    }
}
