namespace OutOfTheBox.Domain
{
    public class Prisoner
    {
        public int Id { get; set; }
        public string? FirstName { get; set; } // or public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public int CellId { get; set; }
        public Cell? Cell { get; set; }
        public Sentence? Sentence { get; set; }
        public ICollection<Rivalry> Rivalries { get; set; } = new List<Rivalry>();
    }
}
