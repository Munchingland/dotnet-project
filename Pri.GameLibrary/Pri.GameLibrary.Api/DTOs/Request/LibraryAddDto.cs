using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class LibraryAddDto
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
