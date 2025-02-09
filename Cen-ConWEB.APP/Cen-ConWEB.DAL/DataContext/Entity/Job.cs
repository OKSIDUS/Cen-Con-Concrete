namespace Cen_ConWEB.DAL.DataContext.Entity
{
    public class Job
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string Location { get; set; }
        public decimal SquareFeet { get; set; }
        public decimal Depth { get; set; }
        public string? ConcreteCustomer { get; set; }
        public int OrderId { get; set; }
        public string? ConcreteSupplierName { get; set; }
        public int ConcreteSupplierId { get; set; }
        public string PourType { get; set; }
        public string? FinishTypeName{ get; set; }
        public int FinishTypeId { get; set; }
        public string? JobTypeName { get; set; }
        public int JobType { get; set; }
        public string? Status { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CrewName { get; set; }
        public int CrewId { get; set; }
    }
}
