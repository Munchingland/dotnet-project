using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class DevelopersCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please select a date")]
        [DateValid(ErrorMessage = "Date must be in the past")]
        public DateTime CreationDate { get; set; }

        public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var date = (DateTime)value;
                return date < DateTime.Now;
            }
        }
    }
    
}
