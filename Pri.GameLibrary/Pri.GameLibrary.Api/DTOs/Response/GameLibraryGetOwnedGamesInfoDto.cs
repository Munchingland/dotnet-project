namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GameLibraryGetOwnedGamesInfoDto : GamesGetByIdDto
    {
        public bool HasReviewed { get; set; }
        public int ReviewId { get; set; }
        public string Description { get; set; }
    }
}
