using CodeHero.Wordle.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeHero.Wordle.Database.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public BaseRepository(DbSet<T> dbSet, DbContext dbContext)
        {
            _dbSet = dbSet;
            _dbContext = dbContext;

            _dbContext.Database.EnsureCreated();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate) => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
