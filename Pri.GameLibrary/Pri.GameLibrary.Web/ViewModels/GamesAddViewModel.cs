using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Web.ViewModels
{
    public class GamesAddViewModel
    {
        [Display(Name ="Naam")]
        [Required(ErrorMessage ="Gelieve een game naam in te geven")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Gelieve een developer te selecteren")]
        [Display(Name ="Developer")]
        public int DeveloperId { get; set; }
        public IEnumerable<SelectListItem> Developers { get; set; }
        [Display(Name="Platformen")]
        public IEnumerable<int> PlatformIds { get; set; }
        public IEnumerable<SelectListItem> Platforms { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Publicatiedatum ")]
        public DateTime ReleaseDate { get; set; }
    }
}
