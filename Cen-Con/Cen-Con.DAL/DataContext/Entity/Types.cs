using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_Con.DAL.DataContext.Entity
{
    [Table("TypesDB")]
    public class Types
    {
        [Key]
        [Column("Id")]
        public int Id {  get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}
