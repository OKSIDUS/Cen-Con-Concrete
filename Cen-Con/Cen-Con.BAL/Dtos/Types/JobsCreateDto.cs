
using static Cen_Con.BAL.Dtos.Types.JobsDto;

namespace Cen_Con.BAL.Dtos.Types
{
    public class JobsCreateDto
    {
        public int ClientId { get; set; }
        public string Location { get; set; }
        public decimal SquareFeet { get; set; }
        public decimal Depth { get; set; }
        public ConcreteOrder OrderBy { get; set; }
        public int ConcreteSupplierId { get; set; }
        public string PourType { get; set; }
        public int FinishTypeId { get; set; }
        public int JobType { get; set; }

    }
}
