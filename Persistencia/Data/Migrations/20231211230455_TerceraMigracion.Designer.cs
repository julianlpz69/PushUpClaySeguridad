﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Data;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(ProyectoDBContext))]
    [Migration("20231211230455_TerceraMigracion")]
    partial class TerceraMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Dominio.Entities.CategoriaPersona", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("NombreCategoria")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_categoria");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("categoria_persona", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombreCategoria = "Auxiliar"
                        },
                        new
                        {
                            Id = 2,
                            NombreCategoria = "Cajero"
                        },
                        new
                        {
                            Id = 3,
                            NombreCategoria = "Supervisor"
                        },
                        new
                        {
                            Id = 4,
                            NombreCategoria = "Vigilante"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("IdDep")
                        .HasColumnType("int")
                        .HasColumnName("id_dep");

                    b.Property<string>("NombreCiudad")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_ciudad");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdDep" }, "id_dep");

                    b.ToTable("ciudad", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdDep = 1,
                            NombreCiudad = "Bucaramanga"
                        },
                        new
                        {
                            Id = 2,
                            IdDep = 1,
                            NombreCiudad = "Floridablanca"
                        },
                        new
                        {
                            Id = 3,
                            IdDep = 1,
                            NombreCiudad = "Giron"
                        },
                        new
                        {
                            Id = 4,
                            IdDep = 1,
                            NombreCiudad = "Piedecuesta"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.ContactoPersona", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.Property<int?>("IdContacto")
                        .HasColumnType("int")
                        .HasColumnName("id_contacto");

                    b.Property<int?>("IdPersona")
                        .HasColumnType("int")
                        .HasColumnName("id_persona");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdContacto" }, "id_contacto");

                    b.HasIndex(new[] { "IdPersona" }, "id_persona");

                    b.ToTable("contacto_persona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateOnly?>("FechaContrato")
                        .HasColumnType("date")
                        .HasColumnName("fecha_contrato");

                    b.Property<DateOnly?>("FechaFin")
                        .HasColumnType("date")
                        .HasColumnName("fecha_fin");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("IdEmpleado")
                        .HasColumnType("int")
                        .HasColumnName("id_empleado");

                    b.Property<int?>("IdEstado")
                        .HasColumnType("int")
                        .HasColumnName("id_estado");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCliente" }, "id_cliente");

                    b.HasIndex(new[] { "IdEmpleado" }, "id_empleado");

                    b.HasIndex(new[] { "IdEstado" }, "id_estado");

                    b.ToTable("contrato", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaContrato = new DateOnly(2009, 1, 11),
                            FechaFin = new DateOnly(2023, 1, 11),
                            IdCliente = 2,
                            IdEmpleado = 1,
                            IdEstado = 1
                        },
                        new
                        {
                            Id = 2,
                            FechaContrato = new DateOnly(2022, 2, 11),
                            FechaFin = new DateOnly(2023, 2, 11),
                            IdCliente = 4,
                            IdEmpleado = 3,
                            IdEstado = 1
                        },
                        new
                        {
                            Id = 3,
                            FechaContrato = new DateOnly(2022, 3, 11),
                            FechaFin = new DateOnly(2023, 3, 11),
                            IdCliente = 6,
                            IdEmpleado = 5,
                            IdEstado = 2
                        },
                        new
                        {
                            Id = 4,
                            FechaContrato = new DateOnly(2022, 4, 11),
                            FechaFin = new DateOnly(2023, 4, 11),
                            IdCliente = 8,
                            IdEmpleado = 7,
                            IdEstado = 1
                        },
                        new
                        {
                            Id = 5,
                            FechaContrato = new DateOnly(2022, 5, 11),
                            FechaFin = new DateOnly(2023, 5, 11),
                            IdCliente = 10,
                            IdEmpleado = 9,
                            IdEstado = 3
                        },
                        new
                        {
                            Id = 6,
                            FechaContrato = new DateOnly(2022, 6, 11),
                            FechaFin = new DateOnly(2023, 6, 11),
                            IdCliente = 2,
                            IdEmpleado = 11,
                            IdEstado = 1
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("IdPais")
                        .HasColumnType("int")
                        .HasColumnName("id_pais");

                    b.Property<string>("NombreDep")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_dep");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdPais" }, "id_pais");

                    b.ToTable("departamento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdPais = 1,
                            NombreDep = "Santander"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("estado", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Activo"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Finalizado"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Pendiente"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("NombrePais")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_pais");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("pais", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombrePais = "Colombia"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateOnly?>("DateRegistro")
                        .HasColumnType("date")
                        .HasColumnName("date_registro");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("direccion");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("id_categoria");

                    b.Property<int?>("IdCiudad")
                        .HasColumnType("int")
                        .HasColumnName("id_ciudad");

                    b.Property<string>("IdPersona")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id_persona");

                    b.Property<int?>("IdTipoPersona")
                        .HasColumnType("int")
                        .HasColumnName("id_tipo_persona");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("IdPersona")
                        .IsUnique();

                    b.HasIndex(new[] { "IdCategoria" }, "id_categoria");

                    b.HasIndex(new[] { "IdCiudad" }, "id_ciudad");

                    b.HasIndex(new[] { "IdTipoPersona" }, "id_tipo_persona");

                    b.ToTable("persona", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistro = new DateOnly(2009, 1, 11),
                            IdCategoria = 4,
                            IdCiudad = 3,
                            IdPersona = "123459",
                            IdTipoPersona = 1,
                            Nombre = "Carlos David"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistro = new DateOnly(2011, 1, 11),
                            IdCiudad = 1,
                            IdPersona = "123468",
                            IdTipoPersona = 2,
                            Nombre = "Karla Lopez"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistro = new DateOnly(2009, 1, 11),
                            IdCategoria = 1,
                            IdCiudad = 4,
                            IdPersona = "123477",
                            IdTipoPersona = 1,
                            Nombre = "Hector Hernandez"
                        },
                        new
                        {
                            Id = 4,
                            DateRegistro = new DateOnly(2013, 1, 11),
                            IdCiudad = 1,
                            IdPersona = "123486",
                            IdTipoPersona = 2,
                            Nombre = "Juan Sanches"
                        },
                        new
                        {
                            Id = 5,
                            DateRegistro = new DateOnly(2009, 1, 11),
                            IdCategoria = 4,
                            IdCiudad = 1,
                            IdPersona = "123494",
                            IdTipoPersona = 1,
                            Nombre = "Pablo Gaviria"
                        },
                        new
                        {
                            Id = 6,
                            DateRegistro = new DateOnly(2022, 1, 11),
                            IdCiudad = 3,
                            IdPersona = "123505",
                            IdTipoPersona = 2,
                            Nombre = "Elon Musk"
                        },
                        new
                        {
                            Id = 7,
                            DateRegistro = new DateOnly(2009, 1, 11),
                            IdCategoria = 4,
                            IdCiudad = 3,
                            IdPersona = "123553",
                            IdTipoPersona = 1,
                            Nombre = "Leidy gaga"
                        },
                        new
                        {
                            Id = 8,
                            DateRegistro = new DateOnly(2009, 1, 11),
                            IdCiudad = 1,
                            IdPersona = "123741",
                            IdTipoPersona = 2,
                            Nombre = "Michael Jackson"
                        },
                        new
                        {
                            Id = 9,
                            DateRegistro = new DateOnly(2009, 1, 11),
                            IdCategoria = 1,
                            IdCiudad = 4,
                            IdPersona = "123562",
                            IdTipoPersona = 1,
                            Nombre = "Fredy Mercury"
                        },
                        new
                        {
                            Id = 10,
                            DateRegistro = new DateOnly(2021, 1, 11),
                            IdCiudad = 1,
                            IdPersona = "123635",
                            IdTipoPersona = 2,
                            Nombre = "Fredy Fasbear"
                        },
                        new
                        {
                            Id = 11,
                            DateRegistro = new DateOnly(2009, 1, 11),
                            IdCategoria = 4,
                            IdCiudad = 3,
                            IdPersona = "132456",
                            IdTipoPersona = 1,
                            Nombre = "Finn el Humano"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Programacion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("IdContrato")
                        .HasColumnType("int")
                        .HasColumnName("id_contrato");

                    b.Property<int?>("IdEmpleado")
                        .HasColumnType("int")
                        .HasColumnName("id_empleado");

                    b.Property<int?>("IdTurno")
                        .HasColumnType("int")
                        .HasColumnName("id_turno");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdContrato" }, "id_contrato");

                    b.HasIndex(new[] { "IdEmpleado" }, "id_empleado")
                        .HasDatabaseName("id_empleado1");

                    b.HasIndex(new[] { "IdTurno" }, "id_turno");

                    b.ToTable("programacion", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdUsuarioFK")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioFK");

                    b.ToTable("refresh_token", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RolName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("rolName");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RolName = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            RolName = "Empleado"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipo_contacto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Celular"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Email"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipo_persona", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Empleado"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Cliente"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<float?>("HoraTurnoFinal")
                        .HasColumnType("float")
                        .HasColumnName("hora_turno_final");

                    b.Property<float?>("HoraTurnoInicio")
                        .HasColumnType("float")
                        .HasColumnName("hora_turno_inicio");

                    b.Property<string>("NombreTurno")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_turno");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("turno", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HoraTurnoFinal = 12f,
                            HoraTurnoInicio = 6f,
                            NombreTurno = "Mañana"
                        },
                        new
                        {
                            Id = 2,
                            HoraTurnoFinal = 8f,
                            HoraTurnoInicio = 12f,
                            NombreTurno = "Tarde"
                        },
                        new
                        {
                            Id = 3,
                            HoraTurnoFinal = 12f,
                            HoraTurnoInicio = 8f,
                            NombreTurno = "Noche"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaveUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.Property<string>("CorreoUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.UsuarioRol", b =>
                {
                    b.Property<int>("IdUsuarioFK")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFK")
                        .HasColumnType("int");

                    b.HasKey("IdUsuarioFK", "IdRolFK");

                    b.HasIndex("IdRolFK");

                    b.ToTable("userRol", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.HasOne("Dominio.Entities.Departamento", "IdDepNavigation")
                        .WithMany("Ciudads")
                        .HasForeignKey("IdDep")
                        .HasConstraintName("ciudad_ibfk_1");

                    b.Navigation("IdDepNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.ContactoPersona", b =>
                {
                    b.HasOne("Dominio.Entities.TipoContacto", "IdContactoNavigation")
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("IdContacto")
                        .HasConstraintName("contacto_persona_ibfk_2");

                    b.HasOne("Dominio.Entities.Persona", "IdPersonaNavigation")
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("IdPersona")
                        .HasConstraintName("contacto_persona_ibfk_1");

                    b.Navigation("IdContactoNavigation");

                    b.Navigation("IdPersonaNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.Contrato", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "IdClienteNavigation")
                        .WithMany("ContratoIdClienteNavigations")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("contrato_ibfk_1");

                    b.HasOne("Dominio.Entities.Persona", "IdEmpleadoNavigation")
                        .WithMany("ContratoIdEmpleadoNavigations")
                        .HasForeignKey("IdEmpleado")
                        .HasConstraintName("contrato_ibfk_2");

                    b.HasOne("Dominio.Entities.Estado", "IdEstadoNavigation")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEstado")
                        .HasConstraintName("contrato_ibfk_3");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdEmpleadoNavigation");

                    b.Navigation("IdEstadoNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.HasOne("Dominio.Entities.Pais", "IdPaisNavigation")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPais")
                        .HasConstraintName("departamento_ibfk_1");

                    b.Navigation("IdPaisNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.HasOne("Dominio.Entities.CategoriaPersona", "IdCategoriaNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("persona_ibfk_2");

                    b.HasOne("Dominio.Entities.Ciudad", "IdCiudadNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdCiudad")
                        .HasConstraintName("persona_ibfk_3");

                    b.HasOne("Dominio.Entities.TipoPersona", "IdTipoPersonaNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersona")
                        .HasConstraintName("persona_ibfk_1");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdCiudadNavigation");

                    b.Navigation("IdTipoPersonaNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.Programacion", b =>
                {
                    b.HasOne("Dominio.Entities.Contrato", "IdContratoNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("IdContrato")
                        .HasConstraintName("programacion_ibfk_1");

                    b.HasOne("Dominio.Entities.Persona", "IdEmpleadoNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("IdEmpleado")
                        .HasConstraintName("programacion_ibfk_3");

                    b.HasOne("Dominio.Entities.Turno", "IdTurnoNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("IdTurno")
                        .HasConstraintName("programacion_ibfk_2");

                    b.Navigation("IdContratoNavigation");

                    b.Navigation("IdEmpleadoNavigation");

                    b.Navigation("IdTurnoNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.RefreshToken", b =>
                {
                    b.HasOne("Dominio.Entities.Usuario", "Usuario")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUsuarioFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Entities.UsuarioRol", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", "Rol")
                        .WithMany("UsuariosRols")
                        .HasForeignKey("IdRolFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Usuario", "Usuario")
                        .WithMany("UsuarioRols")
                        .HasForeignKey("IdUsuarioFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Entities.CategoriaPersona", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Contrato", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudads");
                });

            modelBuilder.Entity("Dominio.Entities.Estado", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Navigation("ContactoPersonas");

                    b.Navigation("ContratoIdClienteNavigations");

                    b.Navigation("ContratoIdEmpleadoNavigations");

                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Navigation("UsuariosRols");
                });

            modelBuilder.Entity("Dominio.Entities.TipoContacto", b =>
                {
                    b.Navigation("ContactoPersonas");
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Turno", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Dominio.Entities.Usuario", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsuarioRols");
                });
#pragma warning restore 612, 618
        }
    }
}
