using System.ComponentModel.DataAnnotations;

namespace PracticeUdemy.Dto
{
    public class RegisterDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }


        public string[] Roles { get; set; }
    }
}
