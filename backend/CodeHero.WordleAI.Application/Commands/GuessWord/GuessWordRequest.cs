using CodeHero.WordleAI.Application.Commands.GuessWord.Model;
using MediatR;

namespace CodeHero.WordleAI.Application.Commands.GuessWord
{
    public class GuessWordRequest : IRequest<GuessWordResponse>
    {
        public IEnumerable<string> Wrong { get; set; }
        public IEnumerable<CorrectLetterRequest> Correct { get; set; }
        public IEnumerable<MisplacedLetterRequest> Misplaced { get; set; }
        public IEnumerable<string> Tried { get; set; }
    }
}
