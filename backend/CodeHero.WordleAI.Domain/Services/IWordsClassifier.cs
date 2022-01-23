using CodeHero.WordleAI.Domain.Model;

namespace CodeHero.WordleAI.Domain.Services
{
    public interface IWordsClassifier
    {
        Task<IEnumerable<Word>> ClassifyAsync(IEnumerable<Word> words);
    }
}
