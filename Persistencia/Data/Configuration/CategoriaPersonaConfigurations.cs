using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<CategoriaPersona>
    {
        public void Configure(EntityTypeBuilder<CategoriaPersona> entity){

            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoria_persona");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .HasColumnName("nombre_categoria");


            entity.HasData(
                new CategoriaPersona{Id = 1, NombreCategoria = "Auxiliar"},
                new CategoriaPersona{Id = 2, NombreCategoria = "Cajero"},
                new CategoriaPersona{Id = 3, NombreCategoria = "Supervisor"},
                new CategoriaPersona{Id = 4, NombreCategoria = "Vigilante"}
            );

        }
    }
}