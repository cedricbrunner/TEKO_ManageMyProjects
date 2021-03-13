using ManageMyProjects.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ManageMyProjects.Data
{
    public class ManageMyProjectDbContext : DbContext
    {
        public ManageMyProjectDbContext(DbContextOptions<ManageMyProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<ProcedureModel> ProcedureModels { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<PhasesActivity> PhasesActivities { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<ExternalCost> ExternalCosts { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Cost> Costs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<Department>().ToTable("Department");
                modelBuilder.Entity<ProcedureModel>().ToTable("ProcedureModel");
                modelBuilder.Entity<Employee>().ToTable("Employee");
                modelBuilder.Entity<Function>().ToTable("Function");
                modelBuilder.Entity<Project>().ToTable("Project");
                modelBuilder.Entity<Phase>().ToTable("Phase");
                modelBuilder.Entity<PhasesActivity>().ToTable("PhasesActivitiy");
                modelBuilder.Entity<Milestone>().ToTable("Milestone");
                modelBuilder.Entity<ExternalCost>().ToTable("ExternalCost");
                modelBuilder.Entity<Status>().ToTable("Status");
                modelBuilder.Entity<Cost>().ToTable("Cost");


            }
            catch(Exception e)
            {
                Console.WriteLine("OnModelCreating Exception: " + e.ToString());
            }
        }


        //public DbSet<ManageMyProjects.Models.Status> Status { get; set; }
    }
}

