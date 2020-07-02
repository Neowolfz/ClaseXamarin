using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UnicornHamApi.Entities.Models
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hamburguesas> Hamburguesas { get; set; }
        public virtual DbSet<Ingredientes> Ingredientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=classxm.database.windows.net;Database=NetCoreHam;User ID=demo;Password=abcd.1234;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hamburguesas>(entity =>
            {
                entity.Property(e => e.HamName)
                    .HasColumnName("Ham Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ingredientes>(entity =>
            {
                entity.Property(e => e.HamId).HasColumnName("HamID");

                entity.Property(e => e.Ingre1).HasMaxLength(50);

                entity.Property(e => e.Ingre2).HasMaxLength(50);

                entity.Property(e => e.Ingre3).HasMaxLength(50);

                entity.HasOne(d => d.Ham)
                    .WithMany(p => p.Ingredientes)
                    .HasForeignKey(d => d.HamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_ToTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
