﻿// <auto-generated />
using System;
using ManageMyProjects.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManageMyProjects.Migrations
{
    [DbContext(typeof(ManageMyProjectDbContext))]
    [Migration("20210310082643_new projct")]
    partial class newprojct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManageMyProjects.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeWorkload")
                        .HasColumnType("int");

                    b.Property<int>("FunctionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FunctionId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ManageMyProjects.Models.ExternalCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExternalCostAmountPlanned")
                        .HasColumnType("int");

                    b.Property<int>("ExternalCostAmountReal")
                        .HasColumnType("int");

                    b.Property<string>("ExternalCostTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalCostTyp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhaseActivityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhaseActivityId");

                    b.ToTable("ExternalCost");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Function", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FunctionTyp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Milestone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MilestoneDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MilestoneName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhaseId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhaseId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Milestone");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Phase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PhaseEndDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PhaseEndDateRealized")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhaseProgress")
                        .HasColumnType("int");

                    b.Property<DateTime>("PhaseReview")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PhaseStartDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PhaseStartDateRealized")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("Phase");
                });

            modelBuilder.Entity("ManageMyProjects.Models.PhasesActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("FileContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("PhaseActivityBudget")
                        .HasColumnType("int");

                    b.Property<DateTime>("PhaseActivityEndDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PhaseActivityEndDateRealized")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PhaseActivityExpense")
                        .HasColumnType("int");

                    b.Property<string>("PhaseActivityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhaseActivityProgress")
                        .HasColumnType("int");

                    b.Property<DateTime>("PhaseActivityStartDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PhaseActivityStartDateRealized")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PhaseId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PhaseId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("PhasesActivity");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Priority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PriorityType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("ManageMyProjects.Models.ProcedureModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProcedureModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProcedureModel");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int?>("ProcedureModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProjectApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProjectEndDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProjectEndDateRealized")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectProgress")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProjectStartDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProjectStartDateRealized")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProcedureModelId");

                    b.HasIndex("StatusId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Employee", b =>
                {
                    b.HasOne("ManageMyProjects.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageMyProjects.Models.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManageMyProjects.Models.ExternalCost", b =>
                {
                    b.HasOne("ManageMyProjects.Models.PhasesActivity", "PhaseActivity")
                        .WithMany()
                        .HasForeignKey("PhaseActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManageMyProjects.Models.Milestone", b =>
                {
                    b.HasOne("ManageMyProjects.Models.Phase", "Phase")
                        .WithMany()
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageMyProjects.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Phase", b =>
                {
                    b.HasOne("ManageMyProjects.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("ManageMyProjects.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("ManageMyProjects.Models.PhasesActivity", b =>
                {
                    b.HasOne("ManageMyProjects.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageMyProjects.Models.Phase", "Phase")
                        .WithMany()
                        .HasForeignKey("PhaseId");

                    b.HasOne("ManageMyProjects.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("ManageMyProjects.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("ManageMyProjects.Models.Project", b =>
                {
                    b.HasOne("ManageMyProjects.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageMyProjects.Models.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageMyProjects.Models.ProcedureModel", "ProcedureModel")
                        .WithMany()
                        .HasForeignKey("ProcedureModelId");

                    b.HasOne("ManageMyProjects.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
