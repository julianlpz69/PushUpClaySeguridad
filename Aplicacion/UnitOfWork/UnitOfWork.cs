

using Applicacion.Repository;
using Application.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Applicacion.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProyectoDBContext _context; 
        
        private ICategoriaPersona _CategoriaPersonas;
        private IRol _Roles ;
        private IUsuario _Usuarios ;
        private IContactoPersona _ContactoPersonas ;
        private IContrato _Contratos ;
        private IEstado _Estados ;
        private IPersona _Personas ;
        private IProgramacion _Programaciones ;
        private ITipoContacto _TipoContactos ;
        private ITipoPersona _TipoPersonas ;
        private ITurno _Turnos ;


        public UnitOfWork(ProyectoDBContext context){
            _context = context;
        }

        
       public ICategoriaPersona CategoriaPersonas
       {
        get{
            if (_CategoriaPersonas == null)
            {
                _CategoriaPersonas = new CategoriaPersonaRepository(_context);
            }
            return _CategoriaPersonas;
        }
       }


       public IContactoPersona ContactoPersonas
       {
        get{
            if (_ContactoPersonas == null)
            {
                _ContactoPersonas = new ContactoPersonaRepository(_context);
            }
            return _ContactoPersonas;
        }
       }


       public IContrato Contratos
       {
        get{
            if (_Contratos == null)
            {
                _Contratos = new ContratoRepository(_context);
            }
            return _Contratos;
        }
       }




       public IEstado Estados
       {
        get{
            if (_Estados == null)
            {
                _Estados = new EstadoRepository(_context);
            }
            return _Estados;
        }
       }


       public IPersona Personas
       {
        get{
            if (_Personas == null)
            {
                _Personas = new PersonaRepository(_context);
            }
            return _Personas;
        }
       }



       public IProgramacion Programaciones
       {
        get{
            if (_Programaciones == null)
            {
                _Programaciones = new ProgramacionRepository(_context);
            }
            return _Programaciones;
        }
       }


       public ITipoContacto TipoContactos
       {
        get{
            if (_TipoContactos == null)
            {
                _TipoContactos = new TipoContactoRepository(_context);
            }
            return _TipoContactos;
        }
       }


       public ITipoPersona TipoPersonas
       {
        get{
            if (_TipoPersonas == null)
            {
                _TipoPersonas = new TipoPersonaRepository(_context);
            }
            return _TipoPersonas;
        }
       }


       public ITurno Turnos
       {
        get{
            if (_Turnos == null)
            {
                _Turnos = new TurnoRepository(_context);
            }
            return _Turnos;
        }
       }

       

        public IRol Roles
        {
            get{
                if (_Roles == null)
                {
                    _Roles = new RolRepository(_context);
                }
                return _Roles;
            }
        }



        public IUsuario Usuarios
        {
            get{
                if (_Usuarios == null)
                {
                    _Usuarios = new UsuarioRepository(_context);
                }
                return _Usuarios;
            }
        }



    public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }