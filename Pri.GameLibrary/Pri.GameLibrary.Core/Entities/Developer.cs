﻿namespace Pri.GameLibrary.Core.Entities
{
    public class Developer : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}