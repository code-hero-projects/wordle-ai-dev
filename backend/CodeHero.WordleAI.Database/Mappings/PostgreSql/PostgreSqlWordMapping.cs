using CodeHero.WordleAI.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeHero.WordleAI.Database.Mappings.PostgreSql
{
    public class PostgreSqlWordMapping : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.ToTable("word");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Characters)
                .IsRequired();
        }
    }
}
