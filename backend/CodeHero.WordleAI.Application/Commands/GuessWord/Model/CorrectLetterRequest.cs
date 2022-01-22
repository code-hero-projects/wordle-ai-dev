namespace CodeHero.WordleAI.Application.Commands.GuessWord.Model
{
    public class CorrectLetterRequest
    {
        public string Letter { get; set; }
        public int Position { get; set; }
    }
}
