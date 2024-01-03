namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class ReviewGetByIdDto 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
    }
}
