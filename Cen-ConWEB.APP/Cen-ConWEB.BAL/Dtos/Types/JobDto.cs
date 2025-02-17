﻿namespace Cen_ConWEB.BAL.Dtos.Types
{
    public class JobDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
        public decimal SquareFeet { get; set; }
        public decimal Depth { get; set; }
        public string ConcreteCustomer { get; set; }
        public string ConcreteSupplier { get; set; }
        public string PourType { get; set; }
        public string FinishTypeName { get; set; }
        public string JobTypeName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CrewName { get; set; }
    }
}
