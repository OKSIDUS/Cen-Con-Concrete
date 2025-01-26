using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("Clients")]
    public class Clients
    {
        [Key]
        [Column("ClientId")]
        public int Id { get; set; }
        [Column("FirstName")]
        [Required]
        public string FirstName { get; set; }
        [Column("LastName")]
        [Required]
        public string LastName { get; set; }
        [Column("PhoneNumber")]
        [Required]
        public string PhoneNumber { get; set; }
        [Column("Email")]
        [Required]
        public string Email { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
