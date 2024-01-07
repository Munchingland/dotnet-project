using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class ReviewsCreateDto : ReviewsBaseDto
    {


        [Required(ErrorMessage ="Please review a game")]
        public int GameId { get; set; }
        [Required(ErrorMessage ="Please login")]
        public string UserId { get; set; }

    }


}
