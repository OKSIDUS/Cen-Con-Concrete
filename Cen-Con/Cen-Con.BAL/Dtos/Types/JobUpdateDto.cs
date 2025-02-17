﻿namespace Cen_Con.BAL.Dtos.Types
{
    public class JobUpdateDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Location { get; set; }
        public decimal SquareFeet { get; set; }
        public decimal Depth { get; set; }
        public int OrderedId { get; set; }
        public int ConcreteSupplierId { get; set; }
        public string PourType { get; set; }
        public int FinishTypeId { get; set; }
        public int JobType { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CrewId { get; set; }

    }
}