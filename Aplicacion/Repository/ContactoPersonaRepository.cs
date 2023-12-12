using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;
    public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersona
    {
        private readonly ProyectoDBContext _context;

        public ContactoPersonaRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ContactoPersona>> EmpleadosVigilantes()
        {
            var empleados = await _context.ContactoPersonas
                .Where(contacto => contacto.IdPersonaNavigation.IdCategoriaNavigation.NombreCategoria == "Vigilante" 
                                    && contacto.IdContactoNavigation.Descripcion == "Celular" )
                .ToListAsync();

            return empleados;
        }
    }