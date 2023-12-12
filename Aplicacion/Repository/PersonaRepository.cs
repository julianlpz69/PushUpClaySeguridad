using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        private readonly ProyectoDBContext _context;

        public PersonaRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Persona>> Empleados()
        {
            var empleados = await _context.Personas
                .Where(empleado => empleado.IdTipoPersonaNavigation.Descripcion == "Empleado")
                .ToListAsync();

            return empleados;
        }



        public async Task<IEnumerable<Persona>> EmpleadosVigilantes()
        {
            var empleados = await _context.Personas
                .Where(empleado => empleado.IdTipoPersonaNavigation.Descripcion == "Empleado" 
                                    && empleado.IdCategoriaNavigation.NombreCategoria == "Vigilante")
                .ToListAsync();

            return empleados;
        }



        public async Task<IEnumerable<Persona>> ClientesBGA()
        {
            var clientes = await _context.Personas
                .Where(cliente => cliente.IdTipoPersonaNavigation.Descripcion == "Cliente"
                                    && cliente.IdCiudadNavigation.NombreCiudad == "Bucaramanga")
                .ToListAsync();

            return clientes;
        }



        public async Task<IEnumerable<Persona>> EmpleadosGP()
        {
            var empleados = await _context.Personas
                .Where(empleado => empleado.IdTipoPersonaNavigation.Descripcion == "empleado"
                                    && empleado.IdCiudadNavigation.NombreCiudad == "Giron" || empleado.IdCiudadNavigation.NombreCiudad == "Piedecuesta")
                .ToListAsync();

            return empleados;
        }





        public async Task<IEnumerable<Persona>> Clientes5Years()
        {
            var clientes = await _context.Personas
                .Where(cliente => cliente.IdTipoPersonaNavigation.Descripcion == "Cliente"
                                    && cliente.DateRegistro.Value < DateOnly.FromDateTime(DateTime.Now).AddYears(-5))
                .ToListAsync();

            return clientes;
        }
    }