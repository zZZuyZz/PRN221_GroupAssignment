using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BO.Models
{
    public partial class RealEstateManagementContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public RealEstateManagementContext()
        {
        }

        public RealEstateManagementContext(DbContextOptions<RealEstateManagementContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("RealEstateManagement");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("create_by");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("update_by");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.BookingAgencies)
                    .HasForeignKey(d => d.AgencyId)
                    .HasConstraintName("FK__Bookings__Agency__32E0915F");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BookingCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Bookings__Custom__31EC6D26");

                entity.HasOne(d => d.RealEstate)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RealEstateId)
                    .HasConstraintName("FK__Bookings__update__30F848ED");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContractDate).HasColumnType("date");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("create_by");

                entity.Property(e => e.DepositAmount).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("update_by");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.ContractAgencies)
                    .HasForeignKey(d => d.AgencyId)
                    .HasConstraintName("FK__Contracts__Agenc__37A5467C");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ContractCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Contracts__Custo__36B12243");

                entity.HasOne(d => d.RealEstate)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.RealEstateId)
                    .HasConstraintName("FK__Contracts__updat__35BCFE0A");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("create_by");

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Sescription).HasColumnType("text");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("update_by");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.FinalCustomer)
                    .WithMany(p => p.ProductFinalCustomers)
                    .HasForeignKey(d => d.FinalCustomerId)
                    .HasConstraintName("FK__Products__FinalC__2D27B809");

                entity.HasOne(d => d.Investor)
                    .WithMany(p => p.ProductInvestors)
                    .HasForeignKey(d => d.InvestorId)
                    .HasConstraintName("FK__Products__update__2C3393D0");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Products__Projec__2E1BDC42");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("create_by");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectContent).HasMaxLength(255);

                entity.Property(e => e.ProjectGeoLocationUrl).HasMaxLength(50);

                entity.Property(e => e.ProjectLocation).HasMaxLength(50);

                entity.Property(e => e.ProjectStatus).HasMaxLength(50);

                entity.Property(e => e.ProjectTitle).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("update_by");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Investor)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.InvestorId)
                    .HasConstraintName("FK__Projects__update__29572725");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.UpdateBy)
                    .HasColumnType("datetime")
                    .HasColumnName("update_by");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleId__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
