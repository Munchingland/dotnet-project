namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GameLibraryGetByUserIdDto
    {
        public List<GameLibraryGetOwnedGamesInfoDto> Items { get; set; } = new List<GameLibraryGetOwnedGamesInfoDto>();
    }
}
