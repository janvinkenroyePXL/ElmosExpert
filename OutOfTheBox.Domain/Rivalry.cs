namespace OutOfTheBox.Domain
{
    public class Rivalry
    {
        public int PrisonerId { get; set; }
        public Prisoner? Prisoner { get; set; }
        public int RivalId { get; set; }
        public Prisoner? Rival { get; set; }

    }
}
