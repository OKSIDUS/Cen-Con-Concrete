using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    public class ConcreteOrder
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Ordered")]
        public string OrderedBy { get; set; }
    }
}
