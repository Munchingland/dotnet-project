namespace Pri.GameLibrary.Web.ViewModels
{
    public class GamesGetByIdViewModel:BaseViewModel
    {
        public double AverageReview { get; set; }
        public string Developer { get; set; }
        public IEnumerable<string> Platforms { get; set; }
        public string ReleaseDate { get; set; }
    }
}
