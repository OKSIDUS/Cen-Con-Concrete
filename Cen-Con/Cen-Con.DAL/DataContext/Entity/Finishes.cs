using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("Finishes")]
    public class Finishes
    {
        [Key]
        [Column("FinishTypeId")]
        public int Id { get; set; }
        [Column("FinishName")]
        [Required]
        public string FinishName { get; set; }
    }
}
