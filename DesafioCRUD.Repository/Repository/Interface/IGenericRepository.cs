using System.Linq.Expressions;


namespace DesafioCRUD.Repository.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        // Novo método para consultas filtradas
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
