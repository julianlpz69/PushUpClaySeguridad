using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> entity){

            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ciudad");

            entity.HasIndex(e => e.IdDep, "id_dep");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdDep).HasColumnName("id_dep");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(50)
                .HasColumnName("nombre_ciudad");

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDep)
                .HasConstraintName("ciudad_ibfk_1");

            entity.HasData(
                new Ciudad{Id=1, NombreCiudad  = "Bucaramanga", IdDep = 1},
                new Ciudad{Id=2, NombreCiudad  = "Floridablanca", IdDep = 1},
                new Ciudad{Id=3, NombreCiudad  = "Giron", IdDep = 1},
                new Ciudad{Id=4, NombreCiudad  = "Piedecuesta", IdDep = 1}
            );

        }
    }
}