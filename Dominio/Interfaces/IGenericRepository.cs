using System.Linq.Expressions;


namespace Dominio.Interfaces
{
     public interface IGenericRepository<T> where T : class
     {
        Task<T> GetByIdAsync(int id);
        Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search,string Nombre);
        Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsyncString(int pageIndex, int pageSize, string search, string Nombre);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add (T entity);
        void AddRange (IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange (IEnumerable<T> entities);
        void Update (T entity);
     }
}