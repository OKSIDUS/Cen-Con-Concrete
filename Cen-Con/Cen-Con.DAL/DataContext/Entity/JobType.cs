using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("JobTypes")]
    public class JobType
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Type")]
        public string Type { get; set; }
    }
}
