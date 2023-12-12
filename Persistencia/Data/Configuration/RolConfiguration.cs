using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder){
    
            builder.ToTable("rol");

            builder.Property(p => p.RolName)
            .HasColumnName("rolName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.HasData(
                new Rol{Id = 1, RolName = "Administrador"},
                new Rol{Id = 2, RolName = "Empleado"}
            );
    
          
    
        }
    }
}