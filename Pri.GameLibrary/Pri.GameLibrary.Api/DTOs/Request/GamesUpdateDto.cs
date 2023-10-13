namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class GamesUpdateDto:GamesCreateDto
    {
        public int Id {  get; set; }
        public DateTime Update { get; set; }
    }
}
