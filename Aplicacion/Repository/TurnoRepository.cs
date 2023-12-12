using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Application.Repository;
    public class TurnoRepository : GenericRepository<Turno>, ITurno
    {
        private readonly ProyectoDBContext _context;

        public TurnoRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }
    }