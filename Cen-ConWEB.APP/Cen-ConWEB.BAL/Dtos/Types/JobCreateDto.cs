namespace Cen_ConWEB.BAL.Dtos.Types
{
    public class JobCreateDto
    {
        public int ClientId { get; set; }
        public string Location { get; set; }
        public decimal SquareFeet { get; set; }
        public decimal Depth { get; set; }
        public int OrderBy { get; set; }
        public int ConcreteSupplierId { get; set; }
        public string PourType { get; set; }
        public int FinishTypeId { get; set; }
        public int JobType { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CrewId { get; set; }
        //public List<ClientDto>? Clients { get; set; }
        //public List<ConcreteOrderDto>? Customers { get; set; }
        //public List<ConcreteSupplierDto>? Suppliers { get; set; }
        //public List<FinishDto>? Finishes { get; set; }
        //public List<JobTypeDto>? JobTypes { get; set; }
        //public List<CrewDto>? Crews { get; set; }
    }
}
