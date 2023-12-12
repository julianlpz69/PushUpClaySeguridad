using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Application.Repository;
    public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
    {
        private readonly ProyectoDBContext _context;

        public TipoPersonaRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }
    }