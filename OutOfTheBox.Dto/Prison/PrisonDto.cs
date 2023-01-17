﻿namespace OutOfTheBox.Dto
{
    public class PrisonDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<CellDto>? Cells { get; set; }
    }
}