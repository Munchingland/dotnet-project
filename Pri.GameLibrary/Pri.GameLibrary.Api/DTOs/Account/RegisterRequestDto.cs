using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Account
{
    public class RegisterRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool HasApprovedTermsAndConditions { get; set; }
    }
}
