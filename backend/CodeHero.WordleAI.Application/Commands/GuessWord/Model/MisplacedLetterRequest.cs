namespace CodeHero.WordleAI.Application.Commands.GuessWord.Model
{
    public class MisplacedLetterRequest
    {
        public string Letter { get; set; }
        public IEnumerable<int> PositionsTried { get; set; }
    }
}
