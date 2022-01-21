using CodeHero.Wordle.Database.Mappings;
using CodeHero.Wordle.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeHero.Wordle.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        private readonly EntitiesConfiguration _entitiesConfiguration;

        public DatabaseContext(EntitiesConfiguration entitiesConfiguration, DbContextOptions options) : base(options) => _entitiesConfiguration = entitiesConfiguration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _entitiesConfiguration.ApplyConfiguration(modelBuilder);
        }
    }
}
