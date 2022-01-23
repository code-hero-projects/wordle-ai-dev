namespace CodeHero.WordleAI.Application.Commands.GuessWord
{
    public class GuessWordResponse
    {
        public string RecommendedWord { get; set; }
        public IEnumerable<string> Words { get; set; }
    }
}
