using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class ReviewsCreateDto
    {
        public string Description { get; set; }

        [Required(ErrorMessage ="please give a score")]
        [ScoreValid(ErrorMessage ="Please give a score between 0 and 10")]
        public int Score { get; set; }

        [Required(ErrorMessage ="Please review a game")]
        public int GameId { get; set; }
        [Required(ErrorMessage ="Please login")]
        public string UserId { get; set; }

    }
    public class ScoreValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int d = (int)value;
            return d <= 10 && d>=0;
        }
    }

}
