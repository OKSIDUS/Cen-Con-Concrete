using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("Crews")]
    public class Crews
    {
        [Key]
        [Column("CrewId")]
        public int Id { get; set; }
        [Column("CrewName")]
        [Required]
        public string CrewName { get; set; }
        [Column("JobType")]
        [Required]
        public JobTypes JobType { get; set; }

        [Required]
        [Column("PricePerCubicMeter", TypeName = "decimal(10,2)")]
        public decimal PricePerCubicMeter { get; set; }

        public enum JobTypes { Commercial, Residential }
    }
}
