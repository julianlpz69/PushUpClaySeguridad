using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
    {
        public void Configure(EntityTypeBuilder<ContactoPersona> entity){

             entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contacto_persona");

            entity.HasIndex(e => e.IdContacto, "id_contacto");

            entity.HasIndex(e => e.IdPersona, "id_persona");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.ContactoPersonas)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("contacto_persona_ibfk_2");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.ContactoPersonas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("contacto_persona_ibfk_1");

            
            entity.HasData(
                new ContactoPersona{Id = 1, Descripcion = "3132419732", IdContacto=1, IdPersona = 1},
                new ContactoPersona{Id = 2, Descripcion = "3132419732", IdContacto=1, IdPersona = 2},
                new ContactoPersona{Id = 3, Descripcion = "3132419732", IdContacto=1, IdPersona = 3},
                new ContactoPersona{Id = 4, Descripcion = "3132419732", IdContacto=1, IdPersona = 4},
                new ContactoPersona{Id = 5, Descripcion = "3132419732", IdContacto=1, IdPersona = 5},
                new ContactoPersona{Id = 6, Descripcion = "julian@gmial", IdContacto=2, IdPersona = 6},
                new ContactoPersona{Id = 7, Descripcion = "margi@gmial", IdContacto=2, IdPersona = 7},
                new ContactoPersona{Id = 8, Descripcion = "nico@gmial", IdContacto=2, IdPersona = 8},
                new ContactoPersona{Id = 9, Descripcion = "lalala@gmial", IdContacto=2, IdPersona = 9},
                new ContactoPersona{Id = 10, Descripcion = "sopas@gmial", IdContacto=2, IdPersona = 10}
            );

        }
    }
}