using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Application.Repository;
    public class CategoriaPersonaRepository : GenericRepository<CategoriaPersona>, ICategoriaPersona
    {
        private readonly ProyectoDBContext _context;

        public CategoriaPersonaRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }
    }