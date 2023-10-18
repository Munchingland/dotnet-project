namespace Pri.GameLibrary.Web.ViewModels
{
    public class GamesGetByIdViewModel:BaseViewModel
    {
        public double AverageReview { get; set; }
        public BaseViewModel Developer { get; set; }
        public IEnumerable<BaseViewModel> Platforms { get; set; }
        public string ReleaseDate { get; set; }
    }
}
