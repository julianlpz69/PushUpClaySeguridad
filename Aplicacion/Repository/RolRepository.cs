using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Applicacion.Repository;
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        private readonly ProyectoDBContext _context;

        public RolRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }
    }