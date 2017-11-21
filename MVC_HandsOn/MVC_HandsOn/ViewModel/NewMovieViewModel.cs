using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_HandsOn.Models;

namespace MVC_HandsOn.ViewModel
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}