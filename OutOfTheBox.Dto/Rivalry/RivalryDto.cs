namespace OutOfTheBox.Dto 
{
    public class RivalryDto : IDto
    {
        public int PrisonerId { get; set; }
        public PrisonerDto? Prisoner { get; set; }
        public int RivalId { get; set; }
        public PrisonerDto? Rival { get; set; }
    }
}
