namespace Cen_Con.BAL.Dtos.Types
{
    public class ClientsCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
