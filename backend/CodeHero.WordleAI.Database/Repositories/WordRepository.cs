using CodeHero.WordleAI.Domain.Model;
using CodeHero.WordleAI.Domain.Repositories;

namespace CodeHero.WordleAI.Database.Repositories
{
    public class WordRepository : BaseRepository<Word>, IWordRepository
    {
        public WordRepository(DatabaseContext databaseContext) : base(databaseContext.Words, databaseContext)
        {
        }
    }
}
