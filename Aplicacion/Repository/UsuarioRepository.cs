using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Applicacion.Repository;
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
    {
        private readonly ProyectoDBContext _context;

        public UsuarioRepository(ProyectoDBContext context):base(context)
        {
            _context = context;
        }



          public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Usuarios
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        public async Task<Usuario> GetByUserGmailAsync(string userEmail)
        {
            return await _context.Usuarios
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.CorreoUsuario.ToLower() == userEmail.ToLower());
        }
    }