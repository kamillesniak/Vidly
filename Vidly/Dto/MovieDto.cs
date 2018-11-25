using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int NumberInStock { get; set; }
    }
}