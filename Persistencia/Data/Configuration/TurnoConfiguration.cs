using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> entity){

            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("turno");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.HoraTurnoFinal).HasColumnName("hora_turno_final");
            entity.Property(e => e.HoraTurnoInicio).HasColumnName("hora_turno_inicio");
            entity.Property(e => e.NombreTurno)
                .HasMaxLength(50)
                .HasColumnName("nombre_turno");
            
            entity.HasData(
                new Turno {Id = 1, NombreTurno = "Mañana", HoraTurnoFinal = 12, HoraTurnoInicio = 6},
                new Turno {Id = 2, NombreTurno = "Tarde", HoraTurnoFinal = 8, HoraTurnoInicio = 12},
                new Turno {Id = 3, NombreTurno = "Noche", HoraTurnoFinal = 12, HoraTurnoInicio = 8}
            );
            
        }
    }
}