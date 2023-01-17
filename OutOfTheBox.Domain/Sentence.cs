namespace OutOfTheBox.Domain
{
    public class Sentence : IEntity
    {
        public int Id { get; set; }
        public bool IsLifeSentence { get; set; }
        public DateTime? StartOfSentence { get; set; }
        public DateTime? EndOfSentence { get; set; }
        public int PrisonerId { get; set; }
        public Prisoner? Prisoner { get; set; }
    }
}
