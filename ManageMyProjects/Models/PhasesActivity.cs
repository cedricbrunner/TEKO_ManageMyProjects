using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageMyProjects.Models
{
    public class PhasesActivity : BaseEntity
    {
        public string PhaseActivityName { get; set; }
        public int PhaseActivityProgress { get; set; }
        public DateTime PhaseActivityStartDatePlanned { get; set; }
        public DateTime PhaseActivityEndDatePlanned { get; set; }
        public DateTime PhaseActivityStartDateRealized { get; set; }
        public DateTime PhaseActivityEndDateRealized { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? PhaseId { get; set; }
        public Phase Phase { get; set; }

        public int? StatusId { get; set; }
        public Status Status { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public byte[]? FileContent { get; set; }
    }
}
