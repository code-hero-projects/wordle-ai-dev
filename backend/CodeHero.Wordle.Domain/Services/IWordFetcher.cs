using CodeHero.Wordle.Domain.Model;

namespace CodeHero.Wordle.Domain.Services
{
    public interface IWordFetcher
    {
        public Task<IEnumerable<Word>> FetchWordsAsync();
    }
}
