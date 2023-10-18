using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Web.ViewModels
{
    public class GamesAddViewModel
    {
        [Required(ErrorMessage ="Gelieve een game naam in te geven")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Gelieve een developer te selecteren")]
        public int DeveloperId { get; set; }
        public IEnumerable<SelectListItem> Developers { get; set; }
        public IEnumerable<int> PlatformIds { get; set; }
        public IEnumerable<SelectListItem> Platforms { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
