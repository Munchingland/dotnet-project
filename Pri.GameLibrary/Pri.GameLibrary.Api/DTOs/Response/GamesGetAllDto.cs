namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GamesGetAllDto
    {
        public IEnumerable<GamesGetByIdDto> Games { get; set; }
    }
}
