using System.Linq.Expressions;

namespace CodeHero.WordleAI.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListAsync();
        Task SaveChangesAsync();
    }
}
