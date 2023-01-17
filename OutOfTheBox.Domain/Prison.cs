namespace OutOfTheBox.Domain
{
    public class Prison : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<Cell> Cells { get; set; } = new List<Cell>();
    }
}