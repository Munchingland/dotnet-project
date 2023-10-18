using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class PlatformsCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
