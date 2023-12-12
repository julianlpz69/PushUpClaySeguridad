using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoContactoConfiguration : IEntityTypeConfiguration<TipoContacto>
    {
        public void Configure(EntityTypeBuilder<TipoContacto> entity){

            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipo_contacto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");


            entity.HasData(
                new TipoContacto{Id = 1, Descripcion = "Celular"},
                new TipoContacto{Id = 2, Descripcion = "Email"}
            );
        }
    }
}