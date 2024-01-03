namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class ReviewGetByGameIdDto
    {
        public IEnumerable<ReviewGetByIdDto> Reviews { get; set; }
    }
}
