namespace CodeHero.WordleAI.Api.Requests.PostWord
{
    public class PostWordRequest
    {
        public IEnumerable<string> Wrong { get; set; }
        public IEnumerable<CorrectLetter> Correct { get; set; }
        public IEnumerable<MisplacedLetter> Misplaced { get; set; }
        public IEnumerable<string> Tried { get; set; }
    }
}
