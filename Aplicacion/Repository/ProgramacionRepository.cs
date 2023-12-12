using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Application.Repository;
    public class ProgramacionRepository : GenericRepository<Programacion>, IProgramacion
    {
        private readonly ProyectoDBContext _context;

        public ProgramacionRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }
    }