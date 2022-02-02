using CodeHero.WordleAI.Domain.Model;
using CodeHero.WordleAI.Domain.Services;

namespace CodeHero.WordleAI.WordSupplier.Services
{
    public class DistinctLetterClassifier : IWordsClassifier
    {
        public Task<IEnumerable<Word>> ClassifyAsync(IEnumerable<Word> words) => Task.FromResult(
            words.Select(word => new Word() { Characters = word.Characters, DifferentLetters = CountDifferentLetters(word.Characters) }));

        private static int CountDifferentLetters(string word) => word.Distinct().Count();
    }
}
