namespace OutOfTheBox.Dto
{
    public class PrisonerCreateRequest : ICreateRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}