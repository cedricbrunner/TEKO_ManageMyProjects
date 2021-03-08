using ManageMyProjects.ModelBinder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageMyProjects.Models
{
    //[ModelBinder(BinderType = typeof(FormDataJsonBinder))]
    public class Phase : BaseEntity
    {
        public string PhaseName { get; set; }
        public DateTime PhaseReview { get; set; }

        public DateTime PhaseStartDatePlanned { get; set; }
        public DateTime PhaseEndDatePlanned { get; set; }
        public DateTime PhaseStartDateRealized { get; set; }
        public DateTime PhaseEndDateRealized { get; set; }
        public int PhaseProgress { get; set; }
        
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }

        
    }
}
