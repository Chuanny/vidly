using System;
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
        public string Name { get; set; }
        public Genre Gen { get; set; }
        [Required]
        [Display (Name = "Genre")]
        public byte GenId { get; set; }
        [Required]
        [Display(Name =  "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}