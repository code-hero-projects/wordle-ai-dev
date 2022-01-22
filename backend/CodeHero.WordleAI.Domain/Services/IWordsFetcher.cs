using CodeHero.WordleAI.Domain.Model;

namespace CodeHero.WordleAI.Domain.Services
{
    public interface IWordsFetcher
    {
        public Task<IEnumerable<Word>> FetchWordsAsync();
    }
}
