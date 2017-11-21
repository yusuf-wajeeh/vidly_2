using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_HandsOn.Models
{
    public class Movie
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        
        [Display(Name ="Release Date")]
        [Required]
        public DateTime releaseDate { get; set; }

        
        public DateTime? dateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1,20)]
        public int numInStock { get; set; }

        public Genre genre { get; set; }
        public int genreid { get; set; }


    }
}