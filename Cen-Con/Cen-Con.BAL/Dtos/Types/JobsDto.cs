
namespace Cen_Con.BAL.Dtos.Types
{
    public class JobsDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Location { get; set; }
        public decimal SquareFeet { get; set; }
        public decimal Depth { get; set; }
        public ConcreteOrder OrderBy { get; set; }
        public int ConcreteSupplierId { get; set; }
        public string PourType { get; set; }
        public int FinishTypeId { get; set; }
        public int JobType { get; set; }


        public enum ConcreteOrder { Client, Company }

    }
}
