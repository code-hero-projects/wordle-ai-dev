using CodeHero.WordleAI.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeHero.WordleAI.Database.Mappings
{
    public class EntitiesConfiguration
    {
        private readonly IEntityTypeConfiguration<Word> _wordConfiguration;

        public EntitiesConfiguration(IEntityTypeConfiguration<Word> wordConfiguration) => _wordConfiguration = wordConfiguration;

        public void ApplyConfiguration(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(_wordConfiguration);
    }
}
