using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cen_ConWEB.DAL.DataContext.Entity
{
    public class Crew
    {
        public int Id { get; set; }
        public string CrewName { get; set; }
        public int JobTypeId { get; set; }
        public decimal PricePerCubicMeter { get; set; }
    }
}
