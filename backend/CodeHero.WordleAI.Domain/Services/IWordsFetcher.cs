using CodeHero.WordleAI.Domain.Model;

namespace CodeHero.WordleAI.Domain.Services
{
    public interface IWordsFetcher
    {
        Task<IEnumerable<Word>> FetchWordsAsync();
    }
}
