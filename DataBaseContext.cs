using EjercicioVentas.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioVentas
{
    internal class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Rechazo> Rechazo { get; set; }
        public DbSet<Parametria> Parametria { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("ventas_mensuales");
                entity.Property(v => v.Fecha) 
                      .HasColumnName("fecha_informe");
                entity.Property(v => v.Codigo)
                      .HasColumnName("codigo_vendedor");
                entity.Property(v => v.Venta)
                     .HasColumnName("venta");
                entity.Property(v => v.VentaEmpresaGrande)
                     .HasColumnName("venta_empresa_grande");
                entity.HasKey(r => r.Id);
            });
            modelBuilder.Entity<Rechazo>(entity =>
            {
                entity.ToTable("rechazos");
                entity.Property(r => r.Motivo)
                      .HasColumnName("motivo_rechazo");
                entity.Property(r => r.Linea)
                    .HasColumnName("linea_rechazada");
                entity.HasKey(r=> r.Id );

               
            });

            modelBuilder.Entity<Parametria>(entity =>
            {
                entity.ToTable("parametria");
                entity.Property(p => p.Fecha)
                      .HasColumnName("fecha_proceso");
                entity.HasNoKey();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
