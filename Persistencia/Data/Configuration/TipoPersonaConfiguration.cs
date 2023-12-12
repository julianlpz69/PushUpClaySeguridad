using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> entity){

            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipo_persona");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");

            entity.HasData(
                new TipoPersona{Id = 1, Descripcion = "Empleado"},
                new TipoPersona{Id = 2, Descripcion = "Cliente"}
            );
            
        }
    }
}