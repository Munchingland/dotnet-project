using System.ComponentModel.DataAnnotations;
using static Pri.GameLibrary.Api.DTOs.Request.DevelopersCreateDto;

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

        [Required(ErrorMessage = "Please select a date")]
        [DateValid(ErrorMessage = "Date must be in the past")]
        public DateTime BirthDay { get; set; }
        public bool HasApprovedTermsAndConditions { get; set; }
    }
}
