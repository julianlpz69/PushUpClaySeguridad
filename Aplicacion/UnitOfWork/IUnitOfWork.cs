using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Applicacion.UnitOfWork
{
        public interface IUnitOfWork
    {
        Task<int> SaveAsync();

        ICategoriaPersona CategoriaPersonas { get; }

        IUsuario Usuarios { get; }
        IContactoPersona ContactoPersonas { get; }
        IContrato Contratos { get; }
        IEstado Estados { get; }
        IPersona Personas { get; }
        IProgramacion Programaciones { get; }
        IRol Roles { get; }
        ITipoContacto TipoContactos { get; }
        ITipoPersona TipoPersonas { get; }
        ITurno Turnos { get; }
    }
}