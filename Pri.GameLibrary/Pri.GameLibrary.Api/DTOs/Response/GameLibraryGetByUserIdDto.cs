namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GameLibraryGetByUserIdDto
    {
        public IEnumerable<GameLibraryGetOwnedGamesInfoDto> Items { get; set; }
    }
}
