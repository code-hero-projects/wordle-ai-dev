namespace CodeHero.WordleAI.Domain.Model
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Characters { get; set; }
        public int DifferentLetters { get; set; }
        public int MostUsedLetters { get; set; }
    }
}
