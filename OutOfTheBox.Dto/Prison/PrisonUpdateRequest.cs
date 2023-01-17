namespace OutOfTheBox.Dto
{
    public class PrisonUpdateRequest : IUpdateRequest
    {
        public string? Name { get; set; }
        public int? Capacity { get; set; }
    }
}