using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_EF.Entities
{
    using API_EF.Entities;
    using Microsoft.EntityFrameworkCore;

    public partial class EFTRANSITOContext : DbContext
    {
        public EFTRANSITOContext()
        {
        }

        public EFTRANSITOContext(DbContextOptions<EFTRANSITOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.Conductor)
                    .HasForeignKey(d => d.IdMatricula)
                    .HasConstraintName("FK__Conductor__IdMat__38996AB5");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.Property(e => e.FechaExpedicion).HasColumnType("date");

                entity.Property(e => e.NumeroV)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValidoHasta).HasColumnType("date");
            });

            modelBuilder.Entity<Sanciones>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FechaActual)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.Property(e => e.Sancion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdConductorNavigation)
                    .WithMany(p => p.Sanciones)
                    .HasForeignKey(d => d.IdConductor)
                    .HasConstraintName("FK__Sanciones__IdCon__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
