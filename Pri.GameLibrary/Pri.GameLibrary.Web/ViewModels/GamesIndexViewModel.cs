namespace Pri.GameLibrary.Web.ViewModels
{
    public class GamesIndexViewModel
    {
        public IEnumerable<GamesGetByIdViewModel> Items { get; set; }
        public string SearchTerm { get; set; }
    }
}
