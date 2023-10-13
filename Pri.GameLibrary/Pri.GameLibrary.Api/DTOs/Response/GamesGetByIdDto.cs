using Pri.GameLibrary.Core.Entities;

namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GamesGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AverageReview { get; set; }
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public ICollection<int> PlatformIds { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
