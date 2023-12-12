using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> entity){

            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contrato");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.HasIndex(e => e.IdEstado, "id_estado");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaContrato).HasColumnName("fecha_contrato");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ContratoIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("contrato_ibfk_1");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.ContratoIdEmpleadoNavigations)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("contrato_ibfk_2");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("contrato_ibfk_3");
            
            entity.HasData(
                new Contrato{Id = 1, IdCliente = 2, FechaContrato = new DateOnly(2009, 1, 11), IdEmpleado = 1, FechaFin = new DateOnly(2023, 1, 11), IdEstado = 1},
                new Contrato{Id = 2, IdCliente = 4, FechaContrato = new DateOnly(2022, 2, 11), IdEmpleado = 3, FechaFin = new DateOnly(2023, 2, 11), IdEstado = 1},
                new Contrato{Id = 3, IdCliente = 6, FechaContrato = new DateOnly(2022, 3, 11), IdEmpleado = 5, FechaFin = new DateOnly(2023, 3, 11), IdEstado = 2},
                new Contrato{Id = 4, IdCliente = 8, FechaContrato = new DateOnly(2022, 4, 11), IdEmpleado = 7, FechaFin = new DateOnly(2023, 4, 11), IdEstado = 1},
                new Contrato{Id = 5, IdCliente = 10, FechaContrato = new DateOnly(2022, 5, 11), IdEmpleado = 9, FechaFin = new DateOnly(2023, 5, 11), IdEstado = 3},
                new Contrato{Id = 6, IdCliente = 2, FechaContrato = new DateOnly(2022, 6, 11), IdEmpleado = 11, FechaFin = new DateOnly(2023, 6, 11), IdEstado = 1}
            );
        }
    }
}