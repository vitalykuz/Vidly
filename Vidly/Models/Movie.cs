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
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime ReleaseDateTime { get; set; }

        [Required]
        public DateTime AddedToDbDate { get; set; }

        [Required]
        public int NumberInStock { get; set; }

    }

}