using MySqlX.XDevAPI;
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
        [ForeignKey("ClientId")]
        public virtual Clients Client { get; set; } // Навигационное свойство для клиента
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
        public int OrderedId { get; set; }
        [ForeignKey("OrderedId")]
        public virtual ConcreteOrder OrderBy { get; set; }
        [Column("ConcreteSupplierId")]
        [Required]
        public int ConcreteSupplierId { get; set; }
        [ForeignKey("ConcreteSupplierId")]
        public virtual ConcreteSuppliers ConcreteSupplier { get; set; } // Поставщик бетона

        [Column("PourType")]
        [Required]
        public string PourType { get; set; }
        [Column("FinishTypeId")]
        [Required]
        public int FinishTypeId { get; set; }
        [ForeignKey("FinishTypeId")]
        public virtual Finishes FinishType { get; set; } // Тип отделки
        [Column("StatusId")]
        [Required]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Statuses Status { get; set; } // Статус работы
        [Column("CreatedAt")]
        [Required]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Column("CrewId")]
        [Required]
        public int CrewId { get; set; }
        [ForeignKey("CrewId")]
        public virtual Crews Crew { get; set; } // Бригада
        [Column("JobTypeId")]
        [Required]
        public int JobTypeId { get; set; }
        [ForeignKey("JobTypeId")]
        public virtual JobType JobType { get; set; } // Тип работы

    }
}
