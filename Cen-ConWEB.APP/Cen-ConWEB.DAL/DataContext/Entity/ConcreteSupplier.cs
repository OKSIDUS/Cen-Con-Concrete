using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cen_ConWEB.DAL.DataContext.Entity
{
    public class ConcreteSupplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string ContactInfo { get; set; }
    }
}
