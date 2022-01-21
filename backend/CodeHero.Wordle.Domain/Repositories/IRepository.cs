using System.Linq.Expressions;

namespace CodeHero.Wordle.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
