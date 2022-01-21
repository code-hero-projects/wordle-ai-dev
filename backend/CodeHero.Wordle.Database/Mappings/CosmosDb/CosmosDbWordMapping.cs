using CodeHero.Wordle.Database.Configuration;
using CodeHero.Wordle.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeHero.Wordle.Database.Mappings.CosmosDb
{
    public class CosmosDbWordMapping : IEntityTypeConfiguration<Word>
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public CosmosDbWordMapping(DatabaseConfiguration databaseConfiguration) => _databaseConfiguration = databaseConfiguration;

        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Characters)
                .IsRequired();

            builder.HasPartitionKey(x => x.Characters);

            builder.ToContainer(_databaseConfiguration.Containers[0]);
        }
    }
}
