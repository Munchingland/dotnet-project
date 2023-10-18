namespace Pri.GameLibrary.Web.ViewModels
{
    public class GamesIndexViewModel
    {
        public IEnumerable<GamesGetByIdViewModel> Games { get; set; }
        public string SearchTerm { get; set; }
    }
}
