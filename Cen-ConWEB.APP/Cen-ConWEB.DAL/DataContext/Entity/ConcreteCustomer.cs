using System.ComponentModel.DataAnnotations.Schema;

namespace Cen_ConWEB.DAL.DataContext.Entity
{
    public class ConcreteCustomer
    {
        public int Id { get; set; }
        public string OrderedBy { get; set; }
    }
}
