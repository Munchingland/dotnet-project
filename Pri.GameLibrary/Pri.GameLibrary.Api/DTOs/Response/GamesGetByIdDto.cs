using Pri.GameLibrary.Core.Entities;

namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GamesGetByIdDto :BaseDto
    {
        public int AverageReview { get; set; }
        public BaseDto Developer { get; set; }
        public ICollection<BaseDto> Platforms { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
