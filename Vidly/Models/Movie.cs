﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
       
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [NumberBetween]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}