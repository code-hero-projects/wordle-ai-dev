namespace CodeHero.WordleAI.Api.Requests.PostWord
{
    public class MisplacedLetter
    {
        public string Letter { get; set; }
        public IEnumerable<int> PositionsTried { get; set; }
    }
}
