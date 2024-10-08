﻿namespace Pri.GameLibrary.Api.DTOs.Response
{
    public class GamesGetByIdDto :BaseDto
    {
        public double AverageReview { get; set; }
        public BaseDto Developer { get; set; }
        public IEnumerable<BaseDto> Platforms { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AmountOfReviews { get; set; }
    }
}
