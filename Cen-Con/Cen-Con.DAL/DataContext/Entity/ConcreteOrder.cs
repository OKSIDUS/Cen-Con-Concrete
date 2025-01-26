using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("ConcreteOrder")]
    public class ConcreteOrder
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("OrderedBy")]
        public string OrderedBy { get; set; }
    }
}
