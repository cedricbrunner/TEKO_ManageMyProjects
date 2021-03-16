/*
 * Milestone Class 
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
    public class Milestone : BaseEntity
    {
        public string MilestoneName { get; set; }
        public DateTime MilestoneDate { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public int PhaseId { get; set; }
        public Phase Phase { get; set; }
    }
}
