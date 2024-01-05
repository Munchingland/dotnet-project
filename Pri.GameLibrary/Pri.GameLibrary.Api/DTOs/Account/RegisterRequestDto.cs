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

        [MyDate(ErrorMessage ="Invalid date")]
        public DateTime BirthDay { get; set; }
        public bool HasApprovedTermsAndConditions { get; set; }
    }

    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;

        }
    }
}
