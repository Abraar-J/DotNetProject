using Microsoft.AspNetCore.Identity;

namespace PracticeUdemy.Dto
{
    public class ApplicationUser:IdentityUser
    {
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
