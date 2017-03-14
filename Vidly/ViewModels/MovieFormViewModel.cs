using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0; // we do this in order to @Html.HiddenFor(m => m.Id) in New.cshtml to be populated with data
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            GenreId = movie.GenreId;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
        }

        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 270)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        public string Title => Id != 0 ?  "Edit Movie" : "New Movie";
    }
}