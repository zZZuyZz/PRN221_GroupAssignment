using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BO.Models
{
    public partial class RealEstateManagementContext : DbContext
    {
        private static readonly string REAL_ESTATE_CONNECTION_STRING = "RealEstateManagement";

        public RealEstateManagementContext()
        {
        }

        public RealEstateManagementContext(DbContextOptions<RealEstateManagementContext> options)
            : base(options)
        {
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
                optionsBuilder.UseSqlServer(GetConnectionString(REAL_ESTATE_CONNECTION_STRING));
            }
        }

        private static string GetConnectionString(string connectionString)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.BookingUserName).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Content).HasMaxLength(255);

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.BookingAgencies)
                    .HasForeignKey(d => d.AgencyId)
                    .HasConstraintName("FK__Bookings__Agency__45F365D3");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BookingCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Bookings__Custom__44FF419A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Bookings__RealEs__440B1D61");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContractDate).HasColumnType("date");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DepositAmount).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.ContractAgencies)
                    .HasForeignKey(d => d.AgencyId)
                    .HasConstraintName("FK__Contracts__Agenc__4AB81AF0");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ContractCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Contracts__Custo__49C3F6B7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Contracts__Produ__48CFD27E");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.FinalCustomer)
                    .WithMany(p => p.ProductFinalCustomers)
                    .HasForeignKey(d => d.FinalCustomerId)
                    .HasConstraintName("FK__Products__FinalC__403A8C7D");

                entity.HasOne(d => d.Investor)
                    .WithMany(p => p.ProductInvestors)
                    .HasForeignKey(d => d.InvestorId)
                    .HasConstraintName("FK__Products__Invest__3F466844");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Products__Projec__412EB0B6");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectContent).HasMaxLength(255);

                entity.Property(e => e.ProjectGeoLocationUrl).HasMaxLength(50);

                entity.Property(e => e.ProjectLocation).HasMaxLength(50);

                entity.Property(e => e.ProjectStatus).HasMaxLength(50);

                entity.Property(e => e.ProjectTitle).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Investor)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.InvestorId)
                    .HasConstraintName("FK__Projects__Invest__3C69FB99");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleId__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
