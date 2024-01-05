namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GameLibraryGetOwnedGamesInfoDto : GamesGetByIdDto
    {
        public bool HasReviewed { get; set; }
    }
}
