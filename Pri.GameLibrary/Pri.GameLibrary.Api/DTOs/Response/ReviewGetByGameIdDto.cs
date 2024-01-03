namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class ReviewGetByGameIdDto
    {
        public IEnumerable<ReviewGetByIdDto> Items { get; set; }
    }
}
