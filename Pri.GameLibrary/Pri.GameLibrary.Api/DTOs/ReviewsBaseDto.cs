﻿using Pri.GameLibrary.Api.DTOs.Request;
using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs
{
    public class ReviewsBaseDto
    {
        public string Description { get; set; }

        [Required(ErrorMessage = "please give a score")]
        [ScoreValid(ErrorMessage = "Please give a score between 0 and 10")]
        public int Score { get; set; }
    }
    public class ScoreValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int d = (int)value;
            return d <= 10 && d >= 0;
        }
    }
}
