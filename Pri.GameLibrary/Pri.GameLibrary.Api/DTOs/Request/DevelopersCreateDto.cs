﻿using System.ComponentModel.DataAnnotations;

namespace Pri.GameLibrary.Api.DTOs.Request
{
    public class DevelopersCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
