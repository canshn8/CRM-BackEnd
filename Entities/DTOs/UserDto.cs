using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}