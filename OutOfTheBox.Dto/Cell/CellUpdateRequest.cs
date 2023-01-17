namespace OutOfTheBox.Dto
{
    public class CellUpdateRequest : IUpdateRequest
    {
        public int? Capacity { get; set; }
        public bool? IsIsolationCell { get; set; }
        public int? PrisonId { get; set; }
    }
}
