using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name="Number in Stock")]
        [Range(1,20)]
        public int? NumberInStock { get; set; }

        public string Title { get => Id != 0 ? "New Movie" : "Edit Movie";}

        public MovieGenreViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public MovieGenreViewModel()
        {
            Id = 0;
        }
    }
}