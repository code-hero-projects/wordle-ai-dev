namespace CodeHero.WordleAI.Domain.Model
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Characters { get; set; }
        public double Score { get; set; }
    }
}
