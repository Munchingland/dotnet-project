using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Account
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
