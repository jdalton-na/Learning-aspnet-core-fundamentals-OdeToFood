﻿using System.ComponentModel.DataAnnotations;

namespace OldeToFood.Core
{
    public partial class Restaurant
    {

        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; } = String.Empty;

        [Required, StringLength(255)]
        public string? Location { get; set; }

        public CuisineType Cuisine { get; set; }

    }
}