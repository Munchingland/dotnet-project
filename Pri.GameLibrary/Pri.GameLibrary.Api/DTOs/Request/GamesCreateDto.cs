using System.ComponentModel.DataAnnotations;
using static Pri.GameLibrary.Api.DTOs.Request.DevelopersCreateDto;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class GamesCreateDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Must have a developer")]
        public int DeveloperId { get; set; }
        [Required(ErrorMessage ="Must have a platform")]
        public IEnumerable<int> PlatformIds { get; set; }

        [Required(ErrorMessage = "Please select a date")]
        [DateValid(ErrorMessage = "Date must be in the past")]
        public DateTime ReleaseDate { get; set; }
    }
}
