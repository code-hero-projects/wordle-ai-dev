using CodeHero.Wordle.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeHero.Wordle.Database.Mappings.PostrgeSql
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
