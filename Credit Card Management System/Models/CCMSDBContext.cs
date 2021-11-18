using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Credit_Card_Management_System.Models
{
    public partial class CCMSDBContext : DbContext
    {
        public CCMSDBContext()
        {
        }

        public CCMSDBContext(DbContextOptions<CCMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<CourierLog> CourierLogs { get; set; }
        public virtual DbSet<StandardValue> StandardValues { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=D01SMC0222\\SQLEXPRESS2017;Initial Catalog=CreditCardManagementSystem;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application");

                entity.Property(e => e.ApplicationId)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ApplicationID");

                entity.Property(e => e.AnnualIncome).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.CardName).HasMaxLength(50);

                entity.Property(e => e.CardStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.Citizenship).HasDefaultValueSql("((1))");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CorporateEmailId)
                    .HasMaxLength(50)
                    .HasColumnName("CorporateEmailID");

                entity.Property(e => e.CourierName).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .HasColumnName("EmailID");

                entity.Property(e => e.FatherLastName).HasMaxLength(50);

                entity.Property(e => e.FatherName).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HouseNo).HasMaxLength(50);

                entity.Property(e => e.IsShipped).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsTermsAndCondition).HasDefaultValueSql("((1))");

                entity.Property(e => e.Landmark).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MaritalStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.MonthlyIncome).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Pancard).HasMaxLength(10);

                entity.Property(e => e.Pincode).HasMaxLength(50);

                entity.Property(e => e.StatusUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.TrackingNumber).HasMaxLength(50);

                entity.HasOne(d => d.CitizenshipNavigation)
                    .WithMany(p => p.ApplicationCitizenshipNavigations)
                    .HasForeignKey(d => d.Citizenship)
                    .HasConstraintName("FK_Application_Citizenship_Id");

                entity.HasOne(d => d.MaritalStatusNavigation)
                    .WithMany(p => p.ApplicationMaritalStatusNavigations)
                    .HasForeignKey(d => d.MaritalStatus)
                    .HasConstraintName("FK_Application_MaritalStatus_Id");

                entity.HasOne(d => d.ProfessionNavigation)
                    .WithMany(p => p.ApplicationProfessionNavigations)
                    .HasForeignKey(d => d.Profession)
                    .HasConstraintName("FK_Application_Profession_Id");
            });

            modelBuilder.Entity<CourierLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.LogId).HasColumnName("logID");

                entity.Property(e => e.ApplicationId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("applicationId");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.CourierLogs)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourierLogs_Application");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CourierLogs)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_CourierLogs_StandardValues");
            });

            modelBuilder.Entity<StandardValue>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
