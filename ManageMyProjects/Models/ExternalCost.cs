using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageMyProjects.Models
{
    public class ExternalCost : BaseEntity

    {
        public string ExternalCostTitle { get; set; }
        public string ExternalCostTyp { get; set; }
        public int ExternalCostAmountPlanned { get; set; }
        public int ExternalCostAmountReal { get; set; }

        public int PhaseActivityId { get; set; }
        public PhasesActivity PhaseActivity { get; set; }




    }
}
