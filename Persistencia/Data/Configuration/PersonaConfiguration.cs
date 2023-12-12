using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> entity){


             entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persona");

            entity.HasIndex(e => e.IdCategoria, "id_categoria");

            entity.HasIndex(e => e.IdCiudad, "id_ciudad");

            entity.HasIndex(e => e.IdTipoPersona, "id_tipo_persona");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateRegistro).HasColumnName("date_registro");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.IdPersona)
                .HasMaxLength(50)
                .HasColumnName("id_persona");
            entity.HasIndex(e => e.IdPersona).IsUnique();
            entity.Property(e => e.IdTipoPersona).HasColumnName("id_tipo_persona");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("persona_ibfk_2");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("persona_ibfk_3");

            entity.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoPersona)
                .HasConstraintName("persona_ibfk_1");

            
            entity.HasData(
                new Persona {Id = 1, IdPersona = "123459", Nombre = "Carlos David", DateRegistro = new DateOnly(2009, 1, 11), IdTipoPersona = 1, IdCategoria = 4, IdCiudad = 3 },
                new Persona {Id = 2, IdPersona = "123468", Nombre = "Karla Lopez", DateRegistro = new DateOnly(2011, 1, 11), IdTipoPersona = 2, IdCategoria = null, IdCiudad = 1 },
                new Persona {Id = 3, IdPersona = "123477", Nombre = "Hector Hernandez", DateRegistro = new DateOnly(2009, 1, 11), IdTipoPersona = 1, IdCategoria = 1, IdCiudad = 4 },
                new Persona {Id = 4, IdPersona = "123486", Nombre = "Juan Sanches", DateRegistro = new DateOnly(2013, 1, 11), IdTipoPersona = 2, IdCategoria = null, IdCiudad = 1 },
                new Persona {Id = 5, IdPersona = "123494", Nombre = "Pablo Gaviria", DateRegistro = new DateOnly(2009, 1, 11), IdTipoPersona = 1, IdCategoria = 4, IdCiudad = 1 },
                new Persona {Id = 6, IdPersona = "123505", Nombre = "Elon Musk", DateRegistro = new DateOnly(2022, 1, 11), IdTipoPersona = 2, IdCategoria = null, IdCiudad = 3 },
                new Persona {Id = 7, IdPersona = "123553", Nombre = "Leidy gaga", DateRegistro = new DateOnly(2009, 1, 11), IdTipoPersona = 1, IdCategoria = 4, IdCiudad = 3 },
                new Persona {Id = 8, IdPersona = "123741", Nombre = "Michael Jackson", DateRegistro = new DateOnly(2009, 1, 11), IdTipoPersona = 2, IdCategoria = null, IdCiudad = 1 },
                new Persona {Id = 9, IdPersona = "123562", Nombre = "Fredy Mercury", DateRegistro = new DateOnly(2009, 1, 11), IdTipoPersona = 1, IdCategoria = 1, IdCiudad = 4 },
                new Persona {Id = 10, IdPersona = "123635", Nombre = "Fredy Fasbear", DateRegistro = new DateOnly(2021, 1, 11), IdTipoPersona = 2, IdCategoria = null, IdCiudad = 1 },
                new Persona {Id = 11, IdPersona = "132456", Nombre = "Finn el Humano", DateRegistro = new DateOnly(2009, 1, 11), IdTipoPersona = 1, IdCategoria = 4, IdCiudad = 3 }
            );
                
        }
    }
}