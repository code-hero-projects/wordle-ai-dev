using CodeHero.Wordle.Domain.Model;
using CodeHero.Wordle.Domain.Repositories;

namespace CodeHero.Wordle.Database.Repositories
{
    public class WordRepository : BaseRepository<Word>, IWordRepository
    {
        public WordRepository(DatabaseContext databaseContext) : base(databaseContext.Words, databaseContext)
        {
        }
    }
}
