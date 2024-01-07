using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class ReviewsUpdateDto : ReviewsBaseDto
    { 
        public int ReviewId { get; set; }

    }
}
