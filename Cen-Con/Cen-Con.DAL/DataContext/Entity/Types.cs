using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    public class Types
    {
        [Key]
        [Column("Id")]
        public int Id {  get; set; }
        [Column("Name")]
        public char Name { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}
