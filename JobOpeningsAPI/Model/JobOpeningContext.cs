using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobOpeningsAPI.Model
{
    public partial class JobOpeningContext : DbContext
    {
        public JobOpeningContext()
        {
        }

        public JobOpeningContext(DbContextOptions<JobOpeningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DepartmentTbl> DepartmentTbls { get; set; } = null!;
        public virtual DbSet<JobsTbl> JobsTbls { get; set; } = null!;
        public virtual DbSet<LocationTbl> LocationTbls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentTbl>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.ToTable("department_tbl");

                entity.Property(e => e.DeptId).HasColumnName("dept_ID");

                entity.Property(e => e.DeptTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("dept_title");
            });

            modelBuilder.Entity<JobsTbl>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.ToTable("jobs_tbl");

                entity.Property(e => e.JobId).HasColumnName("job_ID");

                entity.Property(e => e.JobClosingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("job_closingDate");

                entity.Property(e => e.JobCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("job_code");

                entity.Property(e => e.JobDeptId).HasColumnName("job_dept_id");

                entity.Property(e => e.JobDescription)
                    .IsUnicode(false)
                    .HasColumnName("job_description");

                entity.Property(e => e.JobLocationId).HasColumnName("job_location_ID");

                entity.Property(e => e.JobPostedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("job_postedDate");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_title");
            });

            modelBuilder.Entity<LocationTbl>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("location_tbl");

                entity.Property(e => e.LocationId).HasColumnName("location_ID");

                entity.Property(e => e.LocationCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location_city");

                entity.Property(e => e.LocationCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location_country");

                entity.Property(e => e.LocationState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location_state");

                entity.Property(e => e.LocationTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("location_title");

                entity.Property(e => e.LocationZip).HasColumnName("location_zip");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
