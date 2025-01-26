using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("Statuses")]
    public class Statuses
    {
        [Key]
        [Column("StatusId")]
        public int Id { get; set; }
        [Column("StatusName")]
        [Required]
        public string StatusName { get; set; }
    }
}
