using CodeHero.WordleAI.Domain.Model;
using CodeHero.WordleAI.Domain.Services;
using CodeHero.WordleAI.Domain.Utils;

namespace CodeHero.WordleAI.WordSupplier.Services.WordsClassifier
{
    public class DistinctMostUsedLettersClassifer : IWordsClassifier
    {
        private readonly IDictionary<char, int> _lettersCounter = new Dictionary<char, int>()
        {
            { 'a', 0 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { 'e', 0 }, { 'f', 0 }, { 'g', 0 }, { 'h', 0 }, { 'i', 0 }, { 'j', 0 }, { 'k', 0 }, { 'l', 0 }, { 'm', 0 },
            { 'n', 0 }, { 'o', 0 }, { 'p', 0 }, { 'q', 0 }, { 'r', 0 }, { 's', 0 }, { 't', 0 }, { 'u', 0 }, { 'v', 0 }, { 'w', 0 }, { 'x', 0 }, { 'y', 0 }, { 'z', 0 }
        };

        public Task<IEnumerable<Word>> ClassifyAsync(IEnumerable<Word> words)
        {
            CountLettersInWords(words);

            var highestScore = words.Max(word => GetMostUsedLetters(word.Characters));
            var divisonScore = Math.Round(highestScore / 1000.0) * 1000;

            var scoredWords = words.Select(word => MapToWordWithScore(word, divisonScore));

            return Task.FromResult(scoredWords);
        }

        private void CountLettersInWords(IEnumerable<Word> words) => words.ForEach(word => word.Characters.Distinct().ForEach(letter => _lettersCounter[letter] += 1));

        private Word MapToWordWithScore(Word word, double divisionScore)
        {
            var distinctLetters = GetDistinctLetters(word.Characters);
            var mostUsedLetters = GetMostUsedLetters(word.Characters);

            var score = distinctLetters + (mostUsedLetters / divisionScore);
            return new Word()
            {
                Characters = word.Characters,
                Score = score
            };
        }

        private int GetDistinctLetters(string characters) => characters.Distinct().Count();

        private int GetMostUsedLetters(string characters) => characters.Distinct().Select(letter => _lettersCounter[letter]).Sum();
    }
}
