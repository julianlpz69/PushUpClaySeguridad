using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Applicacion.Repository;
    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
        private readonly ProyectoDBContext _context;

        public EstadoRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }
    }