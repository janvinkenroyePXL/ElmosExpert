namespace OutOfTheBox.Domain
{
    public class Prison
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public ICollection<Cell> Cells { get; set; } = new List<Cell>();
    }
}