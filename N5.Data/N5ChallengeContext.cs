using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using N5.Shared;

namespace N5.Data
{
    public partial class N5ChallengeContext : DbContext
    {
        public N5ChallengeContext()
        {
        }

        public N5ChallengeContext(DbContextOptions<N5ChallengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<PermissionType> PermissionTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=.;Database=N5Challenge;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.EmployeeFirstName).HasMaxLength(50);

                entity.Property(e => e.EmployeeLastName).HasMaxLength(50);

                entity.Property(e => e.PermissionDate).HasColumnType("date");

                entity.HasOne(d => d.PermissionTypeNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.PermissionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Permissions_PermissionType");
            });

            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
