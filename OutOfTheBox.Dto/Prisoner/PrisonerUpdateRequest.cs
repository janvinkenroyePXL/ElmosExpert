namespace OutOfTheBox.Dto
{
    public class PrisonerUpdateRequest : IUpdateRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}