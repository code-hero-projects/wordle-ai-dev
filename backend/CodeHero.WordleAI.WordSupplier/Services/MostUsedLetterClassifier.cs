using CodeHero.WordleAI.Domain.Model;
using CodeHero.WordleAI.Domain.Services;

namespace CodeHero.WordleAI.WordSupplier.Services
{
    public class MostUsedLetterClassifier : IWordsClassifier
    {
        private readonly IDictionary<char, int> _lettersCounter = new Dictionary<char, int>()
        {
            { 'a', 0 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { 'e', 0 }, { 'f', 0 }, { 'g', 0 }, { 'h', 0 }, { 'i', 0 }, { 'j', 0 }, { 'k', 0 }, { 'l', 0 }, { 'm', 0 }, { 'n', 0 },
            { 'o', 0 }, { 'p', 0 }, { 'q', 0 }, { 'r', 0 }, { 's', 0 }, { 't', 0 }, { 'u', 0 }, { 'v', 0 }, { 'w', 0 }, { 'x', 0 }, { 'y', 0 }, { 'z', 0 }
        };

        public Task<IEnumerable<Word>> ClassifyAsync(IEnumerable<Word> words)
        {
            CountLettersInWords(words);
            return Task.FromResult(AddScoreToWords(words));
        }

        private void CountLettersInWords(IEnumerable<Word> words)
        {
            foreach (var word in words)
            {
                var distinctLetters = word.Characters.Distinct();

                foreach (var letter in distinctLetters)
                {
                    _lettersCounter[letter] += 1;
                }
            }
        }

        private IEnumerable<Word> AddScoreToWords(IEnumerable<Word> words)
        {
            return words.Select(word =>
            {
                var count = 0;
                var distinctLetters = word.Characters.Distinct();
                foreach (var letter in distinctLetters)
                {
                    count += _lettersCounter[letter];
                }

                return new Word()
                {
                    Characters = word.Characters,
                    DifferentLetters = word.DifferentLetters,
                    MostUsedLetters = count
                };
            });
        }
    }
}
