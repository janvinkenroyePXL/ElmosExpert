namespace OutOfTheBox.Dto
{
    public class SentenceDto : IDto
    {
        public int Id { get; set; }
        public bool IsLifeSentence { get; set; }
        public DateTime? StartOfSentence { get; set; }
        public DateTime? EndOfSentence { get; set; }
        public int PrisonerId { get; set; }
        public PrisonerDto? Prisoner { get; set; }
    }
}
