using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class GamesCreateDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Must have a developer")]
        public int DeveloperId { get; set; }
        public IEnumerable<int> PlatformIds { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
