using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("ConcreteSuppliers")]
    public class ConcreteSuppliers
    {
        [Key]
        [Column("SupplierId")]
        public int Id { get; set; }
        [Column("SupplierName")]
        [Required]
        public string SupplierName { get; set; }
        [Column("ContactInfo")]
        public string ContactInfo { get; set; }
    }
}
