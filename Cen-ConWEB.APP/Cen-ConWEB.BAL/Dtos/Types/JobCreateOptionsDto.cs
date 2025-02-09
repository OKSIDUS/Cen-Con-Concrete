namespace Cen_ConWEB.BAL.Dtos.Types
{
    public class JobCreateOptionsDto
    {
        public int ClientId { get; set; }
        public List<ClientDto> Clients { get; set; }
        public List<ConcreteOrderDto> Customers { get; set; }
        public List<ConcreteSupplierDto> Suppliers { get; set; }
        public List<FinishDto> Finishes { get; set; }
        public List<JobTypeDto> JobTypes { get; set; }
        public List<CrewDto> Crews { get; set; }
    }
}
