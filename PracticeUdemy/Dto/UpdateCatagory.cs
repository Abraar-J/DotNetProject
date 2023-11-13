using System.ComponentModel.DataAnnotations;

namespace PracticeUdemy.Dto
{
    public class UpdateCatagory
    {
        [Required]
        [MinLength(5,ErrorMessage = "The Catagory Name Should Contain Minimum 5 Character")]
        [MaxLength(5,ErrorMessage ="The Catagory Name Should Contain Maximun 5 Character")]
        public string catagoryname { get; set; }
    }
}
