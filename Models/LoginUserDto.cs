using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class LoginUserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Passwords are limited to {2} to {1} characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
