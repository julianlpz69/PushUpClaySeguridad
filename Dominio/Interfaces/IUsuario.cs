using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IUsuario : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByRefreshTokenAsync(string refreshToken);
        Task<Usuario> GetByUserGmailAsync(string userEmail);
    }
}