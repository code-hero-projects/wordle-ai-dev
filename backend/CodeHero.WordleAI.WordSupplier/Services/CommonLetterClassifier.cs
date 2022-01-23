using CodeHero.WordleAI.Domain.Model;
using CodeHero.WordleAI.Domain.Services;

namespace CodeHero.WordleAI.WordSupplier.Services
{
    public class CommonLetterClassifier : IWordsClassifier
    {
        private readonly Dictionary<string, float> _letterCounter = new Dictionary<string, float> 
        {
            { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 }, { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 },
            { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 }, { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "z", 0 }
        };

        public Task<IEnumerable<Word>> ClassifyAsync(IEnumerable<Word> words)
        {
            var wordsCount = (float) words.Count();

            foreach (var letter in _letterCounter.Keys)
            {
                var numberOfLetterInAllWords = words.Where(word => word.Characters.Contains(letter)).Count();
                _letterCounter[letter] = numberOfLetterInAllWords / wordsCount;
            }

            return Task.FromResult(words);
        }
    }
}
