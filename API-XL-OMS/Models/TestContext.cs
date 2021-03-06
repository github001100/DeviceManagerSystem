﻿using Microsoft.EntityFrameworkCore;

namespace API_XL_OMS.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=FUSANJIE\\SQLSERVER2012;Database=Test;User ID=sa;Password=kyjj1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccumulatedScrap)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CumulativeTotal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataSynchronizationFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataUpdateFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Efr)
                    .HasColumnName("EFR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EquipmentStatusChangeTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FailureTimes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLevelNodes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturingDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mtbf)
                    .HasColumnName("MTBF")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mttf)
                    .HasColumnName("MTTF")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mttr)
                    .HasColumnName("MTTR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NormalOperationTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfProcessesOnDuty)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfQualifiedProductsOnDuty)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfRepaired)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfReworkedProductsOnDuty)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfWasteProductsOnDuty)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oee)
                    .HasColumnName("OEE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Operator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedStartupTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedWarmUpTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Post)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcedureName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordCreationTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RootNode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shifts)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftsStartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StopTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThreeLevelNode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalFailureTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalMaintenanceTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalQualifiedProducts)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalRunningTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TurnOnTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TwoLevelNode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ReleaseDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartCount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewCount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Others)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OverhaulCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OverhaulQuantity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartsName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcedureName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QualifiedQuantity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpeedOfProgress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TaskPlans)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnqualifiedQuantity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WorkGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Remark)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(10);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50);

                entity.Property(e => e.Crole)
                    .HasColumnName("crole")
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Ename)
                    .HasColumnName("ename")
                    .HasMaxLength(20);

                entity.Property(e => e.Erole)
                    .HasColumnName("erole")
                    .HasMaxLength(20);

                entity.Property(e => e.Lock)
                    .HasColumnName("lock")
                    .HasMaxLength(10);

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(20);

                entity.Property(e => e.Qtxx)
                    .HasColumnName("qtxx")
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(15);

                entity.Property(e => e.Workdz)
                    .HasColumnName("workdz")
                    .HasMaxLength(50);

                entity.Property(e => e.Workgw)
                    .HasColumnName("workgw")
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
