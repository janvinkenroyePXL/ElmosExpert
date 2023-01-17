namespace OutOfTheBox.Dto
{
    public class CellCreateRequest : ICreateRequest
    {
        public int Capacity { get; set; }
        public bool IsIsolationCell { get; set; }
        public int PrisonId { get; set; }
    }
}
