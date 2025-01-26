using static Cen_Con.BAL.Dtos.Types.CrewsCreateDto;

namespace Cen_Con.BAL.Dtos.Types
{
    public class CrewsDto
    {
        public int Id { get; set; }
        public string CrewName { get; set; }
        public int JobTypeId { get; set; }
        public decimal PricePerCubicMeter { get; set; }
    }
}
