using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
    {
        public void Configure(EntityTypeBuilder<Programacion> entity){

             entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("programacion");

            entity.HasIndex(e => e.IdContrato, "id_contrato");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.HasIndex(e => e.IdTurno, "id_turno");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdContrato).HasColumnName("id_contrato");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdTurno).HasColumnName("id_turno");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("programacion_ibfk_1");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("programacion_ibfk_3");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdTurno)
                .HasConstraintName("programacion_ibfk_2");
                
        }
    }
}