namespace OutOfTheBox.Dto
{
    public class PrisonerDto : IDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int CellId { get; set; }
        public CellDto? Cell { get; set; }
        public SentenceDto? Sentence { get; set; }
        public ICollection<RivalryDto> ActiveRivalries { get; set; } = new List<RivalryDto>();
        public ICollection<RivalryDto> PassiveRivalries { get; set; } = new List<RivalryDto>();
    }
}