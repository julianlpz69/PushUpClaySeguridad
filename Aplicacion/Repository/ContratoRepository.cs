using Applicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;
    public class ContratoRepository : GenericRepository<Contrato>, IContrato
    {
        private readonly ProyectoDBContext _context;

        public ContratoRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Contrato>> ContratosActivos()
        {
            var contratos = await _context.Contratos
                .Where(contrato => contrato.IdEstadoNavigation.Descripcion == "Activo")
                .Include(u =>u.IdClienteNavigation)
                .Include(u =>u.IdEmpleadoNavigation)
                .ToListAsync();

            return contratos;
        }
    }