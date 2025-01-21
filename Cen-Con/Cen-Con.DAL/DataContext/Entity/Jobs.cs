using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("Jobs")]
    public class Jobs
    {
        [Key]
        [Column("JobId")]
        public int Id { get; set; }
        [Column("ClientId")]
        [Required]
        public int ClientId { get; set; }
        [Column("Location")]
        [Required]
        public string Location { get; set; }
        [Required]
        [Column("SquareFeet", TypeName = "decimal(10,2)")]
        public decimal SquareFeet { get; set; }
        [Column("Depth", TypeName = "decimal(5,2)")]
        [Required]
        public decimal Depth { get; set; }
        [Column("OrderBy")]
        [Required]
        public ConcreteOrder OrderBy { get; set; }
        [Column("ConcreteSupplierId")]
        [Required]
        public int ConcreteSupplierId { get; set; }
        [Column("PourType")]
        [Required]
        public string PourType { get; set; }
        [Column("FinishTypeId")]
        [Required]
        public int FinishTypeId { get; set; }
        [Column("JobType")]
        [Required]
        public int JobType { get; set; }


        public enum ConcreteOrder { Client, Company }

    }
}
