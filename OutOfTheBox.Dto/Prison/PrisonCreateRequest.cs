namespace OutOfTheBox.Dto
{
    public class PrisonCreateRequest : ICreateRequest
    {
        public string? Name { get; set; }
        public int Capacity { get; set; }
    }
}