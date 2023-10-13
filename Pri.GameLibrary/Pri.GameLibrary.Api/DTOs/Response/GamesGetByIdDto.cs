using Pri.GameLibrary.Core.Entities;

namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GamesGetByIdDto :BaseDto
    {
        public double AverageReview { get; set; }
        public BaseDto Developer { get; set; }
        public IEnumerable<BaseDto> Platforms { get; set; }
        public string ReleaseDate { get; set; }
    }
}
