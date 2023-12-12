using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Application.Repository;
    public class TipoContactoRepository : GenericRepository<TipoContacto>, ITipoContacto
    {
        private readonly ProyectoDBContext _context;

        public TipoContactoRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }
    }