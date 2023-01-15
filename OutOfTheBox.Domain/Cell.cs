namespace OutOfTheBox.Domain
{
    public class Cell
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public bool IsIsolationCell { get; set; }
        public int PrisonId { get; set; }
        public Prison? Prison { get; set; }
        public ICollection<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
    }
}
