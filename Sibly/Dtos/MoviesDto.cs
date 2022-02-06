using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sibly.Dtos
{
    public class MoviesDto
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        public int? NumberInStock { get; set; }
    }
}