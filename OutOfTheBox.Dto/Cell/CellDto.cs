namespace OutOfTheBox.Dto
{
    public class CellDto : IDto
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public bool IsIsolationCell { get; set; }
        public int PrisonId { get; set; }
        public PrisonDto? Prison { get; set; }
        public ICollection<PrisonerDto> Prisoners { get; set; } = new List<PrisonerDto>();
    }
}
