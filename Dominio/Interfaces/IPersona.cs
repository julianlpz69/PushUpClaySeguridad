using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IPersona : IGenericRepository<Persona>
    {
        Task<IEnumerable<Persona>> Empleados();
        Task<IEnumerable<Persona>> EmpleadosVigilantes();
        Task<IEnumerable<Persona>> ClientesBGA();
        Task<IEnumerable<Persona>> EmpleadosGP();
        Task<IEnumerable<Persona>> Clientes5Years();
    }
}