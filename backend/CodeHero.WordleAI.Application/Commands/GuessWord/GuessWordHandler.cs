using CodeHero.WordleAI.Domain.Model;
using CodeHero.WordleAI.Domain.Repositories;
using MediatR;

namespace CodeHero.WordleAI.Application.Commands.GuessWord
{
    public class GuessWordHandler : IRequestHandler<GuessWordRequest, GuessWordResponse>
    {
        private readonly IWordRepository _wordRepository;
        private static readonly IEnumerable<Func<GuessWordRequest, string, bool>> CorrectWordConditions = new List<Func<GuessWordRequest, string, bool>>
        {
            WrongLetters,
            CorrectLetters,
            MisplacedLetters,
            TriedWords
        };

        public GuessWordHandler(IWordRepository wordRepository) => _wordRepository = wordRepository;

        public async Task<GuessWordResponse> Handle(GuessWordRequest request, CancellationToken cancellationToken)
        {
            var allWords = await _wordRepository.ListAsync();
            
            var filteredWords = allWords
                .Where(word => CorrectWordConditions.All(condition => condition(request, word.Characters)));

            var availableWords = filteredWords.Select(word => word.Characters);
            var recommendedWord = filteredWords.Aggregate(AggregateWords).Characters;

            return new GuessWordResponse() { Words = availableWords, RecommendedWord = recommendedWord };
        }

        private static bool WrongLetters(GuessWordRequest request, string currentWord) => !request.Wrong.Any(wrong => currentWord.Contains(wrong));

        private static bool CorrectLetters(GuessWordRequest request, string currentWord) => 
            request.Correct.All(correct => currentWord[correct.Position].ToString() == correct.Letter);

        private static bool MisplacedLetters(GuessWordRequest request, string currentWord) => 
            request.Misplaced.All(misplaced => misplaced.PositionsTried.All(position => currentWord[position].ToString() != misplaced.Letter && currentWord.Contains(misplaced.Letter)));

        private static bool TriedWords(GuessWordRequest request, string currentWord) => !request.Tried.Any(tried => tried == currentWord);

        private static Word AggregateWords(Word selected, Word next)
        {
            if (selected.DifferentLetters > next.DifferentLetters)
            {
                return selected;
            }

            if (selected.DifferentLetters < next.DifferentLetters)
            {
                return next;
            }

            return selected.MostUsedLetters >= next.MostUsedLetters ? selected : next;
        }
    }
}
